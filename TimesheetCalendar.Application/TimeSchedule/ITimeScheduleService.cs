using TimesheetCalendar.Application.TimeSchedule.Dto;
using System;
using System.Threading.Tasks;

namespace TimesheetCalendar.Application.TimeSchedule
{
    public interface ITimeScheduleService
    {
        Task<TimeScheduleDto> GetScheduleableHoursByDay(DayOfWeek day);
    }
}
