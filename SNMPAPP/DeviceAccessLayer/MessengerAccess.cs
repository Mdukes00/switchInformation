using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System.Collections.Generic;
using System.Net;

namespace SNMPAPP.DeviceAccessLayer
{
    public class MessengerAccess : IMessengerAccess
    {
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


        private const string communityString = "passwordstring";
        private const int timeOut = 30000;


        //Gets the SNMP Messenger for retrieving specific infromation
        public IList<Variable> GetMessenger(string ip, string OID)
        {
            return Messenger.Get(VersionCode.V2,
            new IPEndPoint(IPAddress.Parse(ip), 161),
            new OctetString(communityString),
            new List<Variable> { new Variable(new ObjectIdentifier(OID)) },
            timeOut);
        }

        //Preforming a walk
        //Gets the SNMP Messenger for retrieving specific infromation on all the interfaces
        public List<Variable> GetWalkMessenger(string ip, string OID)
        {
            var result = new List<Variable>();
            Messenger.Walk(VersionCode.V2,
                           new IPEndPoint(IPAddress.Parse(ip), 161),
                           new OctetString(communityString),
                           new ObjectIdentifier(OID),
                           result,
                           timeOut,
                           WalkMode.WithinSubtree);
            return result;
        }

    }
}
