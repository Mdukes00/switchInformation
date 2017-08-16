using SNMPAPP.BE;

namespace SNMPAPP.UI
{

    public interface IDeviceSNMP
    {
        Device GetDevice(string ip);
    }
}
