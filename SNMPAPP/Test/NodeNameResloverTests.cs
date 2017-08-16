

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SNMPAPP.BLL;

namespace SNMPAPP.Test
{
    [TestClass]
    public class NodeNameResolverTests
    {
        [TestMethod]
        public void nodeToIPAddress_HostName_IPAddressOfNodeName()
        {
            //setup
            //This test will only work if connected to the network 
            //this is an intergration test. 171.20.183.46 is the actual ip address for hostname Dkdc9400_dc1_1.bll.dk.lego.com
            INodeNameResolver nnr = new NodeNameResolver();
            string nodeNameToTest = "name to resolve";

            //act
            string actual = nnr.nodeToIPAddress(nodeNameToTest);
            string expected = "171.20.183.46";
            //assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void nodeToIPAddress_InvalidHostName_CouldNotResolveErrorTryCatch()
        {
            //setup 
            INodeNameResolver nnr = new NodeNameResolver();
            string nodeNameToTest = "invalid.host.name.to.test";

            //act
            string actual = nnr.nodeToIPAddress(nodeNameToTest);
            string expected = "Could not resolve";

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
