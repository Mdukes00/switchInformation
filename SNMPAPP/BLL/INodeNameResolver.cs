using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMPAPP.BLL
{
    public interface INodeNameResolver
    {
        string nodeToIPAddress(string nodeName);
    }
}
