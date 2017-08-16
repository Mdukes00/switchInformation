using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMPAPP.BLL
{
    public interface ISetResultsToDeviceObject
    {

        void SetUpTimeDay();
        void SetInterfaces();
        void SetSystemUpTimeMinutes();
        void SetSystemUpTimeHour();
        void SetSystemUpTimeDay();
        void SetSystemUpTime();
        void SetDescription();
        void SethostName();
    }
}
