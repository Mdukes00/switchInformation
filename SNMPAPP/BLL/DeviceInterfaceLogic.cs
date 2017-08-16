using Lextm.SharpSnmpLib;
using SNMPAPP.BE;
using SNMPAPP.DeviceAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNMPAPP.BLL
{
    public class DeviceInterfaceLogic : IDeviceInterfaceLogic
    {
        private List<Interface> interfaceList = new List<Interface>();

        private Dictionary<int, Interface> listOfInterfaces;

        private IStringSplitter stringSplitter = new StringSplitter();

        private IGetResults getResults = new GetResults();

        private IMessengerAccess messengerAccess = new MessengerAccess();

        private Device newDeviceToReturn = new Device();

        private List<Variable> portdescriptionResult;
        private List<Variable> linkStatusResult;
        private List<Variable> errorStateResult;
        private List<Variable> desiredStateResult;
        private List<Variable> DownTimeResult;
        private long daysUptime;
        private List<Variable> deviceNameOfCDPresult;
        private List<Variable> vlanNameResult;
        private List<Variable> listOfVlanIDResult;
        private IList<Variable> HostNameResult;
        private IList<Variable> descriptionResult;
        private List<Variable> listOfInterfaceResults;


        private IList<Variable> SystemUpTimeResult { get; set; }


        public Device GetInterfaceInfo(string ip)
        {
            GetAllResults(ip);

            setAllResults();

            return newDeviceToReturn;
        }

        /* 
 **************************************************************************************************************************************************************************
 **************************************************************************************************************************************************************************
 **************************************************************************************************************************************************************************
                                        ***           Getting all results            ***
 **************************************************************************************************************************************************************************
 **************************************************************************************************************************************************************************
 **************************************************************************************************************************************************************************    
*/

        private void GetAllResults(string ip)
        {
            Parallel.Invoke(() => linkStatusResult = getResults.GetListOfLinkStatus(ip), () => GetErrorStateInfo(ip), () => GetDesiredState(ip), () => AddDownTimeToListOfInterfaces(ip), () => GetListOfVlanIDs(ip), () => GetListOfVlanNames(ip), () => GetDeviceNameOfTrunkedInterface(ip), () => GetHostName(ip), () => GetDescription(ip), () => GetSystemUpTime(ip), () => GetListOfInterfaces(ip), () => GetPortDescription(ip));
        }

        private void GetPortDescription(string ip)
        {
            portdescriptionResult = getResults.GetPortDescription(ip);

        }

        private void GetListOfInterfaces(string ip)
        {
            listOfInterfaceResults = getResults.GetListOfInterfaces(ip);
        }

        private void GetHostName(string ip)
        {
            HostNameResult = getResults.GetHostName(ip);
        }

        private void GetDescription(string ip)
        {
            descriptionResult = getResults.GetDescription(ip);
        }

        private void GetSystemUpTime(string ip)
        {
            SystemUpTimeResult = getResults.GetSystemUpTime(ip);
        }

        private int GetSystemUpTimeDay()
        {
            int days = stringSplitter.StrToDateTimeDays(SystemUpTimeResult.First().Data.ToString());
            return days;
        }

        private int GetSystemUpTimeHours()
        {
            int days = stringSplitter.StrToDateTimeHours(SystemUpTimeResult.First().Data.ToString());
            return days;
        }

        private int GetSystemUpTimeMinutes()
        {
            int days = stringSplitter.StrToDateTimeMinutes(SystemUpTimeResult.First().Data.ToString());
            return days;
        }

        private void GetListOfLinkStatus(string ip)
        {

            linkStatusResult = getResults.GetListOfLinkStatus(ip);
        }

        private void GetDeviceNameOfTrunkedInterface(string ip)
        {
            deviceNameOfCDPresult = getResults.GetDeviceNameOfTrunkedInterface(ip);
        }

        private void GetErrorStateInfo(string ip)
        {
            errorStateResult = getResults.GetErrorStateInfo(ip);
        }

        private void GetDesiredState(string ip)
        {
            desiredStateResult = getResults.GetDesiredState(ip);
        }

        private void GetListOfVlanIDs(string ip)
        {
            listOfVlanIDResult = getResults.GetListOfVlanIDs(ip);
        }

        private void GetListOfVlanNames(string ip)
        {
            vlanNameResult = getResults.GetListOfVlanNames(ip);

        }

        private Dictionary<int, Interface> GetID(List<Variable> result)
        {
            Dictionary<int, Interface> resultToList = new Dictionary<int, Interface>();
            foreach (Variable x in result)
            {
                if (x.Data.ToString() == "Null0")
                {
                    Interface newInterface = new Interface();
                    newInterface.name = "Unusable Interface";
                    resultToList.Add(stringSplitter.StrTointerfaceId(x.Id.ToString()), (newInterface));
                }
                else
                {
                    Interface newInterface = new Interface();
                    newInterface.name = x.Data.ToString();
                    resultToList.Add(stringSplitter.StrTointerfaceId(x.Id.ToString()), (newInterface));
                }

            }
            return resultToList;
        }

        private void AddDownTimeToListOfInterfaces(string ip)
        {

            DownTimeResult = getResults.AddDownTimeToListOfInterfaces(ip);
        }

        /* 
        **************************************************************************************************************************************************************************
        **************************************************************************************************************************************************************************
        **************************************************************************************************************************************************************************
                                            ***          Setting all results            ****
        **************************************************************************************************************************************************************************
        **************************************************************************************************************************************************************************
        **************************************************************************************************************************************************************************    
        */
        private void setAllResults()
        {
            Parallel.Invoke(() => SethostName(), () => SetDescription(), () => SetSystemUpTime());
            Parallel.Invoke(() => SetSystemUpTimeDay(), () => SetSystemUpTimeHour(), () => SetSystemUpTimeMinutes(), () => SetInterfaces());
            Parallel.Invoke(() => SetUpTimeDay(), () => setLinkStatus(), () => setPortDescription());
            Parallel.Invoke(() => setErrorState(), () => setDisiredState(), () => setDownTime(daysUptime), () => setListOfVlanIDS(), () => setCDPNeighbor());
            setVlanNames();
        }

        private void setErrorState()
        {

            foreach (var x in errorStateResult)
            {
                Interface newInterface = listOfInterfaces[stringSplitter.StrTointerfaceIdErrorState(x.Id.ToString())];
                newInterface.errorState = Convert.ToInt32(x.Data.ToString());
            }
        }

        private void setDisiredState()
        {
            foreach (var x in desiredStateResult)
            {
                Interface newInterface = listOfInterfaces[stringSplitter.StrTointerfaceId(x.Id.ToString())];
                newInterface.desiredState = Convert.ToInt32(x.Data.ToString());
            }
        }

        private void setListOfVlanIDS()
        {
            foreach (var x in listOfVlanIDResult)
            {
                Interface newInterface = listOfInterfaces[stringSplitter.StrTointerfaceId(x.Id.ToString())];
                newInterface.vlanID = Convert.ToInt32(x.Data.ToString());
            }
        }

        private void setLinkStatus()
        {
            foreach (var x in linkStatusResult)
            {
                Interface newInterface = listOfInterfaces[stringSplitter.StrTointerfaceId(x.Id.ToString())];
                newInterface.linkStatus = Convert.ToInt32(x.Data.ToString());
            }
        }

        private void setVlanNames()
        {
            Dictionary<int, string> vlans = new Dictionary<int, string>();

            foreach (var x in vlanNameResult)
            {
                vlans.Add(stringSplitter.StrTointerfaceId(x.Id.ToString()), x.Data.ToString());
            }
            foreach (var x in listOfInterfaces)
            {
                switch (x.Value.vlanID.ToString())
                {
                    case "routed":
                        x.Value.vlanName = "Routed";
                        break;
                    case "trunk":
                        x.Value.vlanName = "Trunk";
                        break;

                    default:
                        if (x.Value.vlanID != 0)
                        {
                            x.Value.vlanName = vlans.Where(p => p.Key == x.Value.vlanID).Select(p => p.Value).FirstOrDefault().ToString();
                        }
                        else
                        {
                            x.Value.vlanName = "Trunk";
                        }
                        break;
                }
            }
        }

        private void SetUpTimeDay()
        {
            daysUptime = stringSplitter.StrToDateTime(newDeviceToReturn.systemUpTime);
        }

        private void SetInterfaces()
        {
            listOfInterfaces = GetID(listOfInterfaceResults);

            newDeviceToReturn.interfaces = listOfInterfaces;
        }

        private void SetSystemUpTimeMinutes()
        {
            newDeviceToReturn.systemUpTimeMinutes = GetSystemUpTimeMinutes();
        }

        private void SetSystemUpTimeHour()
        {
            newDeviceToReturn.systemUpTimeHours = GetSystemUpTimeHours();
        }

        private void SetSystemUpTimeDay()
        {
            newDeviceToReturn.systemUpTimeDay = GetSystemUpTimeDay();
        }

        private void SetSystemUpTime()
        {
            newDeviceToReturn.systemUpTime = SystemUpTimeResult.First().Data.ToString();
        }

        private void SetDescription()
        {
            newDeviceToReturn.description = descriptionResult.FirstOrDefault().Data.ToString();
        }

        private void SethostName()
        {
            newDeviceToReturn.hostName = HostNameResult.FirstOrDefault().Data.ToString();
        }

        private void setDownTime(long daysUptime)
        {
            Parallel.ForEach(DownTimeResult, (kvp) =>
            {
                long day = stringSplitter.StrToDateTime(kvp.Data.ToString());
                long hour = stringSplitter.StrToDateTimeHours(kvp.Data.ToString());
                long minute = stringSplitter.StrToDateTimeMinutes(kvp.Data.ToString());


                if ((day + hour + minute == 0) & (listOfInterfaces[stringSplitter.StrTointerfaceId(kvp.Id.ToString())].linkStatus == 2))
                {
                    listOfInterfaces[stringSplitter.StrTointerfaceId(kvp.Id.ToString())].downTime = "Unused since restart";
                }
                else if (listOfInterfaces[stringSplitter.StrTointerfaceId(kvp.Id.ToString())].linkStatus == 1)
                {
                    listOfInterfaces[stringSplitter.StrTointerfaceId(kvp.Id.ToString())].downTime = "In Use";
                }
                else if ((day + hour + minute >= 0) & (listOfInterfaces[stringSplitter.StrTointerfaceId(kvp.Id.ToString())].linkStatus == 2))
                {
                    long intvar = daysUptime - day;
                    listOfInterfaces[stringSplitter.StrTointerfaceId(kvp.Id.ToString())].downTime = "Unused for " + intvar.ToString() + " days";
                }
            });
        }

        private void setCDPNeighbor()
        {
            foreach (var x in deviceNameOfCDPresult)
            {
                Interface newInterface = listOfInterfaces[stringSplitter.StrToTrunkedinterfaceId(x.Id.ToString())];
                newInterface.ConnectedDeviceName = x.Data.ToString();
            }
        }

        private void setPortDescription()
        {
            foreach (var x in portdescriptionResult)
            {
                Interface newInterface = listOfInterfaces[stringSplitter.StrTointerfaceId(x.Id.ToString())];
                newInterface.portDescription = x.Data.ToString();
            }
        }

    }
}

