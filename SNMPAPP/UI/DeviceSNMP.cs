using SNMPAPP.BE;
using SNMPAPP.BLL;

namespace SNMPAPP.UI
{
    public class DeviceSNMP : IDeviceSNMP
    {
        private IDeviceInterfaceLogic deviceInterfaceLogic = new DeviceInterfaceLogic();


        public Device GetDevice(string ip)

        {
            return deviceInterfaceLogic.GetInterfaceInfo(ip);
        }

    }
}
