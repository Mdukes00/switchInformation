using System;

namespace SNMPAPP.BLL
{

    //I created this class for all the times i need to split the strings to get information such as time and ID from the OID 
    //In terms of ID I had noticed the last number in the OID on a walking starting with 10101 was always the first usable port and so on.
    public class StringSplitter : IStringSplitter
    {
        public long StrToDateTime(string timeToSplit)
        {
            string[] strSplit = timeToSplit.Split('.');

            if (strSplit.Length == 3)
            {
                string[] strDays = strSplit[0].Split(':');

                return Convert.ToInt32(strDays[0].ToString().Trim());
            }
            return 0;
        }
        public int StrToDateTimeDays(string timeToSplit)
        {
            string[] strSplit = timeToSplit.Split('.');

            if (strSplit.Length == 3)
            {
                string[] strDays = strSplit[0].Split(':');

                return Convert.ToInt32(strDays[0].ToString().Trim());
            }
            return 0;
        }
        public int StrToDateTimeHours(string timeToSplit)
        {
            string[] strSplit = timeToSplit.Split('.');

            if (strSplit.Length == 3)
            {
                string[] strDays = strSplit[1].Split(':');

                return Convert.ToInt32(strDays[0].ToString().Trim());
            }
            return 0;
        }
        public int StrToDateTimeMinutes(string timeToSplit)
        {
            string[] strSplit = timeToSplit.Split('.');

            if (strSplit.Length == 3)
            {
                string[] strDays = strSplit[1].Split(':');

                return Convert.ToInt32(strDays[1].ToString().Trim());
            }
            return 0;
        }

        public int StrTointerfaceId(string oidToSplit)
        {
            string[] strSplit = oidToSplit.Split('.');

            if (strSplit.Length == strSplit.Length)
            {
                string[] strDays = strSplit[strSplit.Length - 1].Split(':');

                return Convert.ToInt32(strDays[0].ToString().Trim());
            }
            return -1;
        }

        public int StrToTrunkedinterfaceId(string oidToSplit)
        {
            string[] strSplit = oidToSplit.Split('.');

            if (strSplit.Length == strSplit.Length)
            {
                string[] strDays = strSplit[strSplit.Length - 2].Split(':');

                return Convert.ToInt32(strDays[0].ToString().Trim());
            }
            return -1;
        }
        public int StrTointerfaceIdErrorState(string oidToSplit)
        {
            string[] strSplit = oidToSplit.Split('.');

            if (strSplit.Length == strSplit.Length)
            {
                string[] strDays = strSplit[strSplit.Length - 2].Split('.');

                return Convert.ToInt32(strDays[0].ToString().Trim());
            }
            return -1;
        }
    }
}

