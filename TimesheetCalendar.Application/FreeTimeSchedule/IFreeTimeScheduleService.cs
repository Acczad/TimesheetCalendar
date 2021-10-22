using TimesheetCalendar.Application.FreeTimeSchedule.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimesheetCalendar.Application.FreeTimeSchedule
{
    public interface IFreeTimeScheduleService
    {
        Task<List<FreeTimeScheduleDto>> GetFreeTimesByDay(DayOfWeek dayOfWeek);
    }
}
