using TimesheetCalendar.Domain;
using System;

namespace TimesheetCalendar.Application.FreeTimeSchedule.Dto
{
    public class FreeTimeScheduleDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public short FromMinute { get; set; }
        public short ToMinute { get; set; }
    }
}
