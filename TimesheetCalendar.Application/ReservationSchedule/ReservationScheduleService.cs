using TimesheetCalendar.Application.ReservationSchedule.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimesheetCalendar.Application.ReservationSchedule
{
    public class ReservationScheduleService : IReservationScheduleService
    {
        public Task<List<ReservationScheduleDto>> GetReservedTimes(DateTime date)
        {
            //TODO Call Repository

            return Task.FromResult(
                new List<ReservationScheduleDto>
                    {   new ReservationScheduleDto
                        {
                            FromMinute=600,
                            ToMinute=700
                        },
                        new ReservationScheduleDto
                        {
                            FromMinute=800,
                            ToMinute=900
                        }
                    });
        }
    }
}
