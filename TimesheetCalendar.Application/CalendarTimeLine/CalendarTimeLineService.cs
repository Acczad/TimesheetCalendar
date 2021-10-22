using TimesheetCalendar.Application.BamaDateTime;
using TimesheetCalendar.Application.FreeTimeSchedule;
using TimesheetCalendar.Application.TimeSchedule;
using System;
using System.Threading.Tasks;
using TimesheetCalendar.Application.ReservationSchedule;
using TimesheetCalendar.Application.ReservationSchedule.Dto;

namespace TimesheetCalendar.Application.CalendarTimeLine
{
    public class CalendarTimeLineService : ICalendarTimeLineService
    {
        private readonly ITimeScheduleService _timeScheduleService;
        private readonly IFreeTimeScheduleService _freeTimeScheduleService;
        private readonly IReservationScheduleService _reservationScheduleService;

        public CalendarTimeLineService
               (ITimeScheduleService timeScheduleService,
                IFreeTimeScheduleService freeTimeScheduleService,
                IReservationScheduleService reservationScheduleService
                )
        {
            _timeScheduleService = timeScheduleService;
            _freeTimeScheduleService = freeTimeScheduleService;
            _reservationScheduleService = reservationScheduleService;
        }

        public async Task<CalendarTimeLineDto> GetAvailbaleTimesForReserve(DateTime date)
        {
            var dayofWeek = DateCalcHelper.GetDayOfWeekByDate(date);

            var currentSchedulableHours =
                await _timeScheduleService.GetScheduleableHoursByDay(dayofWeek);

            var currentFreeTimes =
                await _freeTimeScheduleService.GetFreeTimesByDay(dayofWeek);

            var currentReservedTimes = await _reservationScheduleService.GetReservedTimes(date);

            return CalendarTimeLineCalculator
                .CalcFreeTime(date, currentSchedulableHours, currentFreeTimes, currentReservedTimes);
        }
    }
}
