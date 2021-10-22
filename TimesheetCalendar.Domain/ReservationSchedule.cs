using System;

namespace TimesheetCalendar.Domain
{
    public class ReservationSchedule : BaseEntity
    {
        public DayOfWeek DayOfWeek { get; set; }
        public short FromMinute { get; set; }
        public short ToMinute { get; set; }
    }
}
