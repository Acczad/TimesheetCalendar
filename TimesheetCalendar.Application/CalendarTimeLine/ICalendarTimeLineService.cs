using System.Threading.Tasks;
using System;
using TimesheetCalendar.Application.ReservationSchedule.Dto;

namespace TimesheetCalendar.Application.CalendarTimeLine
{
    public interface ICalendarTimeLineService
    {
        Task<CalendarTimeLineDto> GetAvailbaleTimesForReserve(DateTime day);
    }
}
