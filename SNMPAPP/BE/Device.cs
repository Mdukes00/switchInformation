using System.Collections.Generic;

namespace SNMPAPP.BE
{
    public class Device
    {
        public string hostName { get; set; }
        public string description { get; set; }
        public string systemUpTime { get; set; }
        public int systemUpTimeDay { get; set; }
        public int systemUpTimeHours { get; set; }
        public int systemUpTimeMinutes { get; set; }
        public Dictionary<int, Interface> interfaces { get; set; }
    }
}
