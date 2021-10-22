namespace TimesheetCalendar.Application.CalendarTimeLine.Dto
{
    public class MintuteStatus
    {
        public MintuteStatus(short minute, MinStatus status)
        {
            Status = status;
            Minute = minute;
        }

        public MinStatus Status { get; set; }
        public short Minute { get; set; }

    }
    public enum MinStatus
    {
        Available=0,
        FreeTime=1,
        Reserved=2,
        UnAvailable=3
    }
}
