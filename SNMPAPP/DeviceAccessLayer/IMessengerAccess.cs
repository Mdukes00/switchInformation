using System.Collections.Generic;
using Lextm.SharpSnmpLib;

namespace SNMPAPP.DeviceAccessLayer
{
    public interface IMessengerAccess
    {
        IList<Variable> GetMessenger(string ip, string OID);
        List<Variable> GetWalkMessenger(string ip, string OID);
        IList<Variable> GetBulkMessenger(string ip, List<string> OID);
    }
}
