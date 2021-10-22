using System;

namespace TimesheetCalendar.Domain
{
    public class FreeTimeSchedule : BaseEntity
    {
        public DayOfWeek DayOfWeek { get; set; }
        public short FromMinute { get; set; }
        public short ToMinute { get; set; }
    }
}
