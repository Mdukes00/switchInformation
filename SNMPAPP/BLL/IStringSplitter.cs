namespace SNMPAPP.BLL
{
    public interface IStringSplitter
    {
        int StrTointerfaceId(string oidToSplit);
        int StrToTrunkedinterfaceId(string oidToSplit);
        long StrToDateTime(string timeToSplit);
        int StrToDateTimeDays(string timeToSplit);
        int StrToDateTimeMinutes(string timeToSplit);
        int StrToDateTimeHours(string timeToSplit);
        int StrTointerfaceIdErrorState(string oidToSplit);
    }
}
