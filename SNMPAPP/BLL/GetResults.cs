using Lextm.SharpSnmpLib;
using SNMPAPP.BE;
using SNMPAPP.DeviceAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMPAPP.BLL
{
    public class GetResults : IGetResults
    {
        private IMessengerAccess messengerAccess = new MessengerAccess();

        private IStringSplitter stringSplitter = new StringSplitter();

        private IList<Variable> SystemUpTimeResult;

        private string vlanIDOID = "1.3.6.1.4.1.9.9.68.1.2.2.1.2";
        private string vlanNameOID = "1.3.6.1.4.1.9.9.46.1.3.1.1.4";
        private string ifLastChangeOID = "1.3.6.1.2.1.2.2.1.9.";
        private string linkStatusOID = "1.3.6.1.2.1.2.2.1.8.";
        private string ErrDisableIfStatusCauseOID = "1.3.6.1.4.1.9.9.548.1.3.1.1.2.";
        private string desiredStateOID = "1.3.6.1.2.1.2.2.1.7.";
        private string CDPDeviceNameOID = "1.3.6.1.4.1.9.9.23.1.2.1.1.6";
        private static string listOfInterfacesOID = "1.3.6.1.2.1.2.2.1.2";
        private string hostNameOID = "1.3.6.1.2.1.1.5.0";
        private string descriptionOID = "1.3.6.1.2.1.1.1.0";
        private string systemUpTimeOID = "1.3.6.1.2.1.1.3.0";
        private string portdescriptionOID = "1.3.6.1.2.1.31.1.1.1.18";


        public List<Variable> GetPortDescription(string ip)
        {
            return messengerAccess.GetWalkMessenger(ip, portdescriptionOID);
        }

        public List<Variable> GetListOfInterfaces(string ip)
        {
            return messengerAccess.GetWalkMessenger(ip, listOfInterfacesOID);
        }

        public IList<Variable> GetHostName(string ip)
        {
            return messengerAccess.GetMessenger(ip, hostNameOID);
        }

        public IList<Variable> GetDescription(string ip)
        {
            return messengerAccess.GetMessenger(ip, descriptionOID);
        }

        public IList<Variable> GetSystemUpTime(string ip)
        {
            return messengerAccess.GetMessenger(ip, systemUpTimeOID);
        }

        public int GetSystemUpTimeDay()
        {
            int days = stringSplitter.StrToDateTimeDays(SystemUpTimeResult.First().Data.ToString());
            return days;
        }

        public int GetSystemUpTimeHours()
        {
            int days = stringSplitter.StrToDateTimeHours(SystemUpTimeResult.First().Data.ToString());
            return days;
        }

        public int GetSystemUpTimeMinutes()
        {
            int days = stringSplitter.StrToDateTimeMinutes(SystemUpTimeResult.First().Data.ToString());
            return days;
        }


        public List<Variable> GetListOfLinkStatus(string ip)
        {

            return messengerAccess.GetWalkMessenger(ip, linkStatusOID);
        }

        public List<Variable> GetDeviceNameOfTrunkedInterface(string ip)
        {
            return messengerAccess.GetWalkMessenger(ip, CDPDeviceNameOID);
        }

        public List<Variable> GetErrorStateInfo(string ip)
        {
            return messengerAccess.GetWalkMessenger(ip, ErrDisableIfStatusCauseOID);
        }

        public List<Variable> GetDesiredState(string ip)
        {
            return messengerAccess.GetWalkMessenger(ip, desiredStateOID);
        }

        public List<Variable> GetListOfVlanIDs(string ip)
        {
            return messengerAccess.GetWalkMessenger(ip, vlanIDOID);
        }

        public List<Variable> GetListOfVlanNames(string ip)
        {
            return messengerAccess.GetWalkMessenger(ip, vlanNameOID);

        }

        public Dictionary<int, Interface> GetID(List<Variable> result)
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

        public List<Variable> AddDownTimeToListOfInterfaces(string ip)
        {

            return messengerAccess.GetWalkMessenger(ip, ifLastChangeOID);
        }

    }
}
