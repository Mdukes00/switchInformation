using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lextm.SharpSnmpLib;
using System.Collections.Generic;
using SNMPAPP.DeviceAccessLayer;
using SNMPAPP.UI;
using SNMPAPP.BE;
using System.Collections;
using SNMPAPP.BLL;
using NSubstitute;
using System;

namespace SNMPBasicTests
{
    [TestClass]
    public class UnitTest1
    {
        //basic idea of this basic unit test was to be able to change the OID and test to see if i was actually getting any values back from the device.
        //some times the OID is correct but the switches and routers do not send any or the correct information as the OID documentation expects
        //either outdated OID or switch and routers might need to be upgraded


        Device testDevice = new Device();
        List<Interface> interfaceList = new List<Interface>();
        Dictionary<string, string> result = new Dictionary<string, string>();

        Dictionary<int, Interface> resultToList = new Dictionary<int, Interface>();



        string OIDtotest = "1.3.6.1.2.1.3.1.1.2."; // hostname OID
                                                   //1.3.6.1.4.1.9.9.68.1.2.2.1.2.
                                                   //1.3.6.1.2.1.2.2.1.8

        List<string> OIDs = new List<string> { "1.3.6.1.2.1.1.5.", "1.3.6.1.2.1.1.1.", "1.3.6.1.2.1.1.3." };

        string ip = "171.20.183.46";

        IMessengerAccess ma = new MessengerAccess();
        DeviceSNMP d = new DeviceSNMP();

        [TestMethod]
        public void getHostNameTest()
        {

            testDevice.hostName = "testhomename";
            testDevice.description = "Cisco IOS Software, C2960X Software(C2960X - UNIVERSALK9 - M), Version 15.2(2)E3, RELEASE SOFTWARE (fc3)Technical Support: http://www.cisco.com/techsupport Copyright (c) 1986-2015 by Cisco Systems, Inc. Compiled Wed 26-Aug-15 07:12 by prod_rel_team";
            testDevice.systemUpTime = "43.22:07:52.5600000";
            for (int i = 1; i <= 10; i++)
            {
                result.Add(".1.3.6.1.2.1.2.2.1.2.1010" + i, "GigabitEthernet1/0/" + i);
            }

            IDeviceInterfaceLogic dil = new DeviceInterfaceLogic();



        }


        [TestMethod]
        public void mockedDevice()
        {
          
            //setup
            string ip = "not real";
            var device = Substitute.For<IDeviceSNMP>();
            var igetrusl = Substitute.For<IGetResults>();
            var messenager = Substitute.For<IMessengerAccess>();
            Device mockedDevice = new Device();
            IMessengerAccess ima = new MessengerAccess();

            //act
            ima.GetWalkMessenger(ip,Arg.Any<String>());
            device.GetDevice(ip).Returns(mockedDevice);
            messenager.Received().GetWalkMessenger(ip, Arg.Any<string>());

            //assert
            Assert.AreEqual(mockedDevice, device.GetDevice(ip));           
           

        }


        [TestMethod]
        public void mockedDeviceHostName()
        {

            string ip = "not real";

            IList<Variable> hostVariable = new List<Variable>();

            //   Variable testVar = new Variable(12,ISnmpData);


            IDeviceSNMP device = Substitute.For<IDeviceSNMP>();
            var messenager = Substitute.For<IMessengerAccess>();
            var igetrusl = Substitute.For<IGetResults>();
            //  igetrusl[0].Data.ToString();
            Device device1 = device.GetDevice(ip);


            device.Received().GetDevice(ip);
            //   messenager.Received().GetWalkMessenger(ip,Arg.Any<string>());
            ////   ids.GetDevice(ip);


            //   igetrusl.Received().GetHostName(ip);

            //   // igetrusl.GetHostName(ip).Returns("Hostname");
            //   Device mockedDevice = new Device() { hostName = "Hostname" };
            //   //device = "Hostname";


            //   //string test = device;

            //   //   Assert.AreEqual(mockedDevice, device.GetDevice(ip));

            //   mockedDevice.hostName = "Hostname";
            //   // device.GetDevice(ip).hostName.Returns(mockedDevice.hostName.Returns(igetrusl.Returns(messenager("").GetWalkMessenger("a","a"))));

            //  Assert.AreEqual(mockedDevice, device.GetDevice(ip));



            //    Assert.AreEqual(device.GetDevice("2").hostName, "HostName");

        }


        //Device mockedDevice = new Device();
        //mockedDevice.hostName = "HostName";
        //string ip = "not real";
        //device.GetDevice(ip).hostName.Returns(mockedDevice.hostName);

    }
}
