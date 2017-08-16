using Lextm.SharpSnmpLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNMPAPP.BE;

namespace SNMPAPP.BLL
{
    public interface IGetResults
    {
        List<Variable> GetPortDescription(string ip);

        List<Variable> GetListOfInterfaces(string ip);

        IList<Variable> GetHostName(string ip);

        IList<Variable> GetDescription(string ip);

        IList<Variable> GetSystemUpTime(string ip);

        List<Variable> GetListOfLinkStatus(string ip);

        List<Variable> GetDeviceNameOfTrunkedInterface(string ip);

        List<Variable> GetErrorStateInfo(string ip);

        List<Variable> GetDesiredState(string ip);

        List<Variable> GetListOfVlanIDs(string ip);

        List<Variable> GetListOfVlanNames(string ip);

        List<Variable> AddDownTimeToListOfInterfaces(string ip);
    
    }
}
