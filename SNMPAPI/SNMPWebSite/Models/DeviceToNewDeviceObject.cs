using SNMPAPP.BE;
using System.Collections.Generic;

namespace SNMPWebSite.Models
{
    public class DeviceToNewDeviceObject
    {
        // I believe this class could use some improvement
        public DeviceObject ConvertToNewDevice(Device deviceToConvert)
        {
            DeviceObject DO = new DeviceObject();

            DO.hostName = deviceToConvert.hostName;
            DO.description = deviceToConvert.description;
            DO.systemUpTime = deviceToConvert.systemUpTime;
            DO.systemUpTimeDays = deviceToConvert.systemUpTimeDay;
            DO.systemUpTimeHours = deviceToConvert.systemUpTimeHours;
            DO.systemUpTimeMinutes = deviceToConvert.systemUpTimeMinutes;

            Dictionary<int, DeviceInterfaceObject> doiList = new Dictionary<int, DeviceInterfaceObject>();
            List<DeviceInterfaceObject> iflist = new List<DeviceInterfaceObject>();

            int i = 1;

            foreach (KeyValuePair<int, Interface> x in deviceToConvert.interfaces)
            {
                DeviceInterfaceObject doi = new DeviceInterfaceObject();
                doi.name = x.Value.name;
                doi.linkStatus = GetStatus(x.Value.linkStatus);
                doi.downTime = x.Value.downTime;
                doi.vlanID = x.Value.vlanID;
                doi.vlanName = x.Value.vlanName;
                doiList.Add(i, doi);
                doi.errorState = GetErrorState(CheckShutDownState(x));
                doi.desiredState = GetStatus(x.Value.desiredState);
                DO.interfaces = doiList;
                doi.ConnectedDeviceName = x.Value.ConnectedDeviceName;
                doi.portDescription = x.Value.portDescription;

                i++;
            }
            return DO;
        }

        private int CheckShutDownState(KeyValuePair<int, Interface> x)
        {
            if (x.Value.desiredState == 2)
            {
                return x.Value.errorState = 35;
            }
            else if (x.Value.desiredState == 1 & x.Value.linkStatus == 1)
            {
                return x.Value.errorState = 36;
            }

            return x.Value.errorState;
        }

        static string GetErrorState(int value)
        {
            switch (value)
            {
                case 0: return "Usable";
                case 1: return "'udld' Error State";
                case 2: return "'bpduGuard' Error State";
                case 3: return "'channelMisconfig' Error State";
                case 4: return "'pagpFlap' Error State";
                case 5: return "'dtpFlap' Error State";
                case 6: return "'linkFlap' Error State";
                case 7: return "'l2ptGuard' Error State";
                case 8: return "'dot1xSecurityViolation' Error State";
                case 9: return "'portSecurityViolation' Error State";
                case 10: return "'gbicInvalid' Error State";
                case 11: return "'dhcpRateLimit' Error State";
                case 12: return "'unicastFlood' Error State";
                case 13: return "'vmps' Error State";
                case 14: return "'stormControl' Error State";
                case 15: return "'inlinePower' Error State";
                case 16: return "'arpInspection' Error State";
                case 17: return "'portLoopback' Error State";
                case 18: return "'packetBuffer' Error State";
                case 19: return "'macLimit' Error State";
                case 20: return "'linkMonitorFailure' Error State";
                case 21: return "'oamRemoteFailure' Error State";
                case 22: return "'dot1adIncompEtype' Error State";
                case 23: return "'dot1adIncompTunnel' Error State";
                case 24: return "'sfpConfigMismatch' Error State";
                case 25: return "'communityLimit' Error State";
                case 26: return "'invalidPolicy' Error State";
                case 27: return "'lsGroup' Error State";
                case 28: return "'ekey' Error State";
                case 29: return "'portModeFailure' Error State";
                case 30: return "'pppoeIaRateLimit' Error State";
                case 31: return "'oamRemoteCriticalEvent' Error State";
                case 32: return "'oamRemoteDyingGasp' Error State";
                case 33: return "'oamRemoteLinkFault' Error State";
                case 34: return "'mvrp' Error State";
                case 35: return "Shutdown";
                case 36: return "In Use";

                default:
                    return "Unknown Error State";
            }
        }



        private static string GetStatus(int value)
        {
            switch (value)
            {
                case 1: return "Connected";
                case 2: return "Not Connected";
                case 3: return "Testing";
                case 4: return "Unknown";
                case 5: return "Dormant";
                case 6: return "Not Present";
                case 7: return "Lower Layer Down";

                default:
                    return "Unknown Link Status";
            }
        }
    }

}