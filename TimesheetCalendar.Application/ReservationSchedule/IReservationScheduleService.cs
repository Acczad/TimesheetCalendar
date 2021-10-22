using TimesheetCalendar.Application.ReservationSchedule.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimesheetCalendar.Application.ReservationSchedule
{
    public interface IReservationScheduleService
    {
        Task<List<ReservationScheduleDto>> GetReservedTimes(DateTime date);
    }
}
