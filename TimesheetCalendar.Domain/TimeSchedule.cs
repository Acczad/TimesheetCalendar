using System;

namespace TimesheetCalendar.Domain
{
    public class TimeSchedule : BaseEntity
    {
        public DayOfWeek DayOfWeek { get; set; }
        public short FromHour { get; set; }
        public short ToHour { get; set; }
    }
}
