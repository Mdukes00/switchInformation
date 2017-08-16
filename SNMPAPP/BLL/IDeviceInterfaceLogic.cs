using SNMPAPP.BE;

namespace SNMPAPP.BLL
{
    public interface IDeviceInterfaceLogic
    {
        Device GetInterfaceInfo(string ip);
    }
}
