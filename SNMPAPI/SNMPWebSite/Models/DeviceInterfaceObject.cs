using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNMPWebSite.Models
{
    public class DeviceInterfaceObject
    {
        public string desiredState { get; set; }
        public string name { get; set; }
        public string linkStatus { get; set; }
        public string downTime { get; set; }
        public int vlanID { get; set; }
        public string vlanName { get; set; }
        public string errorState { get; set; }
        public string ConnectedDeviceName { get; set; }
        public string portDescription { get; set; }
    }
}