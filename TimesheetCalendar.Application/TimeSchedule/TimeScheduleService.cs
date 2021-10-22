using TimesheetCalendar.Application.TimeSchedule.Dto;
using TimesheetCalendar.Domain;
using System;
using System.Threading.Tasks;

namespace TimesheetCalendar.Application.TimeSchedule
{
    public class TimeScheduleService : ITimeScheduleService
    {
        public Task<TimeScheduleDto> GetScheduleableHoursByDay(DayOfWeek day)
        {
            //TODO Call repository and filter

            if (day == DayOfWeek.Friday)
                return null; //TODO fix this

            if (day == DayOfWeek.Thursday)
                return Task.FromResult(new TimeScheduleDto
                {
                    DayOfWeek = day,
                    FromHour = 9,
                    ToHour = 13
                });

            return Task.FromResult(new TimeScheduleDto
            {
                DayOfWeek = day,
                FromHour = 9,
                ToHour = 17
            });
        }
    }
}
