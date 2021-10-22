using TimesheetCalendar.Application.FreeTimeSchedule.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimesheetCalendar.Application.FreeTimeSchedule
{
    public class FreeTimeScheduleService : IFreeTimeScheduleService
    {
        public Task<List<FreeTimeScheduleDto>> GetFreeTimesByDay(DayOfWeek dayOfWeek)
        {
            //TODO Call repository and filter

            if (dayOfWeek == DayOfWeek.Friday)
                return Task.FromResult(new List<FreeTimeScheduleDto>()); //TODO fix this

            if (dayOfWeek == DayOfWeek.Saturday)
                return Task.FromResult(new List<FreeTimeScheduleDto>
                {
                    new FreeTimeScheduleDto
                    {
                        DayOfWeek=dayOfWeek,
                        FromMinute=500,
                        ToMinute=560
                    },

                    new FreeTimeScheduleDto
                    {
                        DayOfWeek=dayOfWeek,
                        FromMinute=700,
                        ToMinute=760
                    },
                });

            return Task.FromResult(new List<FreeTimeScheduleDto>()); //TODO fix this
        }
    }
}
