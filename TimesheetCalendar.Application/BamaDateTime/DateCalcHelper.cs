using System;

namespace TimesheetCalendar.Application.BamaDateTime
{
    public static class DateCalcHelper
    {
        public static DayOfWeek GetDayOfWeekByDate(DateTime date)
        {
            return date.DayOfWeek;
        }
    }
}
