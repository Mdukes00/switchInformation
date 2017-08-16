using System;
using System.Net;

namespace SNMPAPP.BLL
{
    public class NodeNameResolver : INodeNameResolver
    {
        public string nodeToIPAddress(string nodeName)
        {
            try
            {
                IPHostEntry hostEntry;
                hostEntry = Dns.GetHostEntry(nodeName);

                //you might get more than one ip for a hostname since 
                //DNS supports more than one record

                if (hostEntry.AddressList.Length >= 0)
                {
                    return hostEntry.AddressList[0].ToString();
                }
                //still need to implanment some type of logging for errors
                //not reachable by because of gaurd on the input field on the web page
                return "Could not resolve";
            }
            //still need to implanment some type of logging for errors
            catch (Exception ex)
            {
                return "Could not resolve";
            }
        }
    }
}


