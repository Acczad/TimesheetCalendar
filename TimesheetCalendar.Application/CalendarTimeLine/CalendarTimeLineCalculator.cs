using TimesheetCalendar.Application.BamaDateTime;
using TimesheetCalendar.Application.CalendarTimeLine.Dto;
using TimesheetCalendar.Application.FreeTimeSchedule.Dto;
using TimesheetCalendar.Application.ReservationSchedule.Dto;
using TimesheetCalendar.Application.TimeSchedule.Dto;
using System.Collections.Generic;
using System;
using System.Linq;

namespace TimesheetCalendar.Application.CalendarTimeLine
{
    public static class CalendarTimeLineCalculator
    {
        public static CalendarTimeLineDto CalcFreeTime(DateTime date,
          TimeScheduleDto SchedulableHours,
          List<FreeTimeScheduleDto> FreeTimes,
          List<ReservationScheduleDto> ReservedTimes)
        {
            var timeSheet = new CalendarTimeLineDto();
            DateTime startTime = new DateTime(date.Year, date.Month, date.Day, SchedulableHours.FromHour, 0, 0);
            var endTime = new DateTime(date.Year, date.Month, date.Day, SchedulableHours.ToHour, 0, 0);
            startTime = GetNewStartDateIfPastFromTodayStartReserve(date, startTime);

            //TODO Refactoring this.
            while (startTime < endTime)
            {

                var minute = TimeCalcHelper.GetMinutesOfDay(startTime);

                if (IsInFreeMinuteRange(FreeTimes, minute))
                {
                    timeSheet.AddStatus((short)minute, MinStatus.FreeTime);
                    startTime = startTime.AddMinutes(1);
                    continue;
                }

                if (IsInReservedMinuteRange(ReservedTimes, minute))
                {
                    timeSheet.AddStatus((short)minute, MinStatus.Reserved);
                    startTime = startTime.AddMinutes(1);
                    continue;
                }

                if (IsInPreCondtionsForTwoHours(date, minute))
                {
                    timeSheet.AddStatus((short)minute, MinStatus.UnAvailable);
                    startTime = startTime.AddMinutes(1);
                    continue;
                }

                timeSheet.AddStatus((short)minute, MinStatus.Available);
                startTime = startTime.AddMinutes(1);
            }

            return timeSheet;
        }

        //TODO Refactoring this dry problem, convert to generic
        private static bool IsInFreeMinuteRange(List<FreeTimeScheduleDto> FreeTimes, int time)
        {
            return FreeTimes.Any(q => q.FromMinute <= time && q.ToMinute >= time);
        }
        private static bool IsInReservedMinuteRange(List<ReservationScheduleDto> reservedTimes, int time)
        {
            return reservedTimes.Any(q => q.FromMinute <= time && q.ToMinute >= time);
        }
        private static bool IsInPreCondtionsForTwoHours(DateTime date, int minute)
        {
            if (date.Date > DateTime.Now)
                return false;

            var newDate = new DateTime(date.Year, date.Month, date.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);

            newDate = newDate.AddHours(2);
            var availManute = TimeCalcHelper.GetMinutesOfDay(newDate);

            if (availManute < minute)
                return false;

            return true;
        }
        private static DateTime GetNewStartDateIfPastFromTodayStartReserve(DateTime date, DateTime startDate)
        {
            if (date > DateTime.Now)
                return startDate;

            if (DateTime.Now > date)
               return new DateTime(date.Year, date.Month, date.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);

            return startDate;
        }
    }
}
