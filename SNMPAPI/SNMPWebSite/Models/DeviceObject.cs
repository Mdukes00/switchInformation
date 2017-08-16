using System.Collections.Generic;

namespace SNMPWebSite.Models
{
    public class DeviceObject
    {
        public string hostName { get; set; }
        public string description { get; set; }
        public string systemUpTime { get; set; }
        public string IpAddress { get; set; }
        public int systemUpTimeDays { get; set; }
        public int systemUpTimeHours { get; set; }
        public int systemUpTimeMinutes { get; set; }
        public Dictionary<int, DeviceInterfaceObject> interfaces { get; set; }
    }
}