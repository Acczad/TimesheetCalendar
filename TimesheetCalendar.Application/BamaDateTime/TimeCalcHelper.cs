using System;

namespace TimesheetCalendar.Application.BamaDateTime
{
    public static class TimeCalcHelper
    {
        public static int GetMinutesOfDay(DateTime time)
        {
            return (int)Math.Round(time.TimeOfDay.TotalMinutes);
        }
    }
}
