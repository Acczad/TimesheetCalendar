using System;

namespace TimesheetCalendar.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}