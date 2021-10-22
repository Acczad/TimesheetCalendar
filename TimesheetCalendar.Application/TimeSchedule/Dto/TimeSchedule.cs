using System;

namespace TimesheetCalendar.Application.TimeSchedule.Dto
{
    public class TimeScheduleDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public short FromHour { get; set; }
        public short ToHour { get; set; }
    }
}
