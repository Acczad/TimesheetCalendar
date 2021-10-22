using TimesheetCalendar.Application.CalendarTimeLine.Dto;
using System;
using System.Collections.Generic;

namespace TimesheetCalendar.Application.ReservationSchedule.Dto
{
    public class CalendarTimeLineDto
    {
        public CalendarTimeLineDto()
        {
            TimeLineStatus = new List<MintuteStatus>();
        }

        public DateTime FromDateTime { get; set; }
        public DateTime UntilDateTime { get; set; }
        public List<MintuteStatus> TimeLineStatus { get; }

        public void AddStatus(short minute, MinStatus status)
        {
            TimeLineStatus.Add(new MintuteStatus(minute, status));
        }
    }

}
