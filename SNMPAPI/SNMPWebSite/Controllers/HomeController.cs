
using SNMPAPP.BE;
using SNMPAPP.BLL;
using SNMPAPP.UI;
using SNMPWebSite.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SNMPWebSite.Controllers
{
    [Authorize(Roles = "groups that have access")]
    public class HomeController : Controller
    {
        private string communityString = ResourceFile.CommunityString;
        private int timeOut = Convert.ToInt32(ResourceFile.TimeOut);
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };

        }

        public ActionResult Index()
        {

            return View();
        }


        [HttpGet]
        public ActionResult showDevice(string sendmsg)
        {
            if (sendmsg.Trim().Length >= 16)
            {
                NodeNameResolver nodeNameResolver = new NodeNameResolver();
                string ip = nodeNameResolver.nodeToIPAddress(sendmsg.Trim());
                IDeviceSNMP lsl = new DeviceSNMP();
                Device model = lsl.GetDevice(ip.Trim());
                if (model.interfaces.Count == 0)
                {    
                    return View("Error");
                }
                DeviceToNewDeviceObject dtno = new DeviceToNewDeviceObject();
                DeviceObject device = dtno.ConvertToNewDevice(model);
                device.IpAddress = ip;


                int portDescriptionEmpty = 0;
                for (int i = 0; i >= device.interfaces.Count; i++)
                {
                    if (device.interfaces[i].portDescription == "")
                    {
                        portDescriptionEmpty++;
                    }
                }
                if (portDescriptionEmpty >= device.interfaces.Count)
                {
                    return View("showDeviceNoPortDescription", device);
                }

          return View(device);
            }

            else
            {
                int portDescriptionIsNotEmpty = 0;
                IDeviceSNMP lsl = new DeviceSNMP();
                Device model = lsl.GetDevice(sendmsg.Trim());
                DeviceToNewDeviceObject dtno = new DeviceToNewDeviceObject();
                DeviceObject device = dtno.ConvertToNewDevice(model);
                device.IpAddress = sendmsg.Trim();
                if (device.interfaces != null)
                {
                    for (int i = 1; i <= device.interfaces.Count; i++)
                    {
                        if (device.interfaces[i].portDescription != "")
                        {
                            portDescriptionIsNotEmpty++;
                        }
                    }
                    if (portDescriptionIsNotEmpty >= 1)
                    {
                        return View(device);
                    }
                    return View("showDeviceNoPortDescription", device);
                }
                return View("Error");
            }


        }
    }
}