using Lextm.SharpSnmpLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SNMPAPP.BLL;
using SNMPAPP.DeviceAccessLayer;
using SNMPAPP.UI;
using System;
using System.Collections.Generic;

namespace SNMPAPP.Test
{
    [TestClass]
    public class UnitTest
    {
        string expectedDescription = "{Cisco IOS Software, C2960X Software (C2960X-UNIVERSALK9-M), Version 15.2(2)E3, RELEASE SOFTWARE (fc3)Technical Support: http://www.cisco.com/techsupportCopyright (c) 1986-2015 by Cisco Systems, Inc.Compiled Wed 26-Aug-15 07:12 by prod_rel_team}";


        [TestMethod]
        public void getHostNameTest_OIDForHostName_HostNameOfDevice()
        {
            //setup
            string ip = "171.20.183.46";
            IGetResults gr = new GetResults();
            DeviceSNMP d = new DeviceSNMP();

            //act
            IList<Variable> result = gr.GetHostName(ip);


            //assert
            Assert.AreEqual("hostname", result[0].Data.ToString());
        }

        [TestMethod]
        public void getDescriptionTest_OIDForDescription_DescriptionOfDevice()
        {
            //setup
            IGetResults gr = new GetResults();
            string ip = "171.20.183.46";
            //act
            IList<Variable> result = gr.GetDescription(ip);
            string actualDescription = result[0].Data.ToString();


            //assert
            Assert.AreEqual(expectedDescription.Contains("Cisco IOS Software"), actualDescription.Contains("Cisco IOS Software"));
        }

    }

}

