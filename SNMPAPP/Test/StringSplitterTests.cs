using Microsoft.VisualStudio.TestTools.UnitTesting;
using SNMPAPP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMPAPP.Test
{
    [TestClass]
    public class StringSplitterTests
    {
        [TestMethod]
        public void StrToDateTime_DayHoursMinutesSecondsMilliseconds_GetDaysAsLong()
        {
            //setup
            IStringSplitter ss = new StringSplitter();
            string stringToSplit = "43.22:07:52.5600000";

            //act
            long actual = ss.StrToDateTime(stringToSplit);
            long expected = 43;

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void StrToDateTimeDays_DayHoursMinutesSecondsMilliseconds_GetDaysAsLong()
        {
            //setup
            IStringSplitter ss = new StringSplitter();
            //"days.hours:minutes:seconds.milliseconds"
            string stringToSplit = "43.22:07:52.5600000";

            //act
            int actual = ss.StrToDateTimeDays(stringToSplit);
            int expected = 43;

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void StrToDateTimeHours_DayHoursMinutesSecondsMilliseconds_GetHoursAsLong()
        {
            //setup
            IStringSplitter ss = new StringSplitter();
            //"days.hours:minutes:seconds.milliseconds"
            string stringToSplit = "43.22:07:52.5600000";

            //act
            int actual = ss.StrToDateTimeHours(stringToSplit);
            int expected = 22;

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void StrToDateTimeMinutes_DayHoursMinutesSecondsMilliseconds_GetMinutesAsLong()
        {
            //setup
            IStringSplitter ss = new StringSplitter();
            //"days.hours:minutes:seconds.milliseconds"
            string stringToSplit = "43.22:07:52.5600000";

            //act
            int actual = ss.StrToDateTimeMinutes(stringToSplit);
            int expected = 07;

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void StrTointerfaceId_OID_GetIdFromOID()
        {
            //setup
            IStringSplitter ss = new StringSplitter();
            //10101 is the id for interface for the first actual interface 0/1, 1/0/1"
            //oid is listOfInterfacesOID .1.3.6.1.2.1.2.2.1.2.ID
            string stringToSplit = ".1.3.6.1.2.1.2.2.1.2.10101";

            //act
            int actual = ss.StrTointerfaceId(stringToSplit);
            int expected = 10101;

            //assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void StrToTrunkedinterfaceId_OID_GetIdFromTrunkedOID()
        {
            //setup
            IStringSplitter ss = new StringSplitter();
            //10101 is the id for interface for the first actual interface 0/1, 1/0/1"
            //oid is CDPDeviceNameOID .1.3.6.1.4.1.9.9.23.1.2.1.1.6
            string stringToSplit = ".1.3.6.1.4.1.9.9.23.1.2.1.1.6.10101.5";

            //act
            int actual = ss.StrToTrunkedinterfaceId(stringToSplit);
            int expected = 10101;

            //assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void StrTointerfaceIdErrorState_OID_GetIdFromErrorStateOID()
        {
            //setup
            IStringSplitter ss = new StringSplitter();
            //10101 is the id for interface for the first actual interface 0/1, 1/0/1"
            //oid is listOfInterfacesOID .1.3.6.1.2.1.2.2.1.2.ID
            string stringToSplit = ".1.3.6.1.2.1.2.2.1.2.10101.1";

            //act
            int actual = ss.StrTointerfaceIdErrorState(stringToSplit);
            int expected = 10101;

            //assert
            Assert.AreEqual(expected, actual);

        }
    }
}

