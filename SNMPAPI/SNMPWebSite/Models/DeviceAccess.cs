using SNMPAPP.BE;
using System.Collections.Generic;

namespace SNMPWebSite.Models
{
    public class DeviceAccess
    {
        public DeviceObject getData()
        {
            //This class is used for testing when I am not connected to the intranet or not on the ACL on the switch.
            //ILexSnmpLib lsl = new LexSnmpLib();
            //Device device = lsl.GetSNMPInfo("10.130.130.65");
            Dictionary<int, Interface> dic = new Dictionary<int, Interface>();
            Interface a = new Interface() { name = "interface 1", linkStatus = 1, vlanID = 1, downTime = "00:38:00" };
            Interface b = new Interface() { name = "interface 2", linkStatus = 1, vlanID = 1, downTime = "20:38:00" };
            Interface c = new Interface() { name = "interface 3", linkStatus = 2, vlanID = 2, downTime = "10:38:00" };
            Interface d = new Interface() { name = "interface 4", linkStatus = 1, vlanID = 1, downTime = "03:38:00" };

            List<Interface> list = new List<Interface>();

            dic.Add(1, a);
            dic.Add(2, b);
            dic.Add(3, c);
            dic.Add(4, d);

            return new DeviceObject { description = "Test description", hostName = "testHostname", systemUpTime = "Test up time" };
        }
    }
}