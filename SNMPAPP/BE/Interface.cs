namespace SNMPAPP.BE
{
    public class Interface
    {
        public string name { get; set; }
        public int linkStatus { get; set; }
        public string downTime { get; set; }
        public int vlanID { get; set; }
        public string vlanName { get; set; }
        public int errorState { get; set; }
        public int desiredState { get; set; }
        public string ConnectedDeviceName { get; set; }
        public string portDescription { get; set; }
    }
}
