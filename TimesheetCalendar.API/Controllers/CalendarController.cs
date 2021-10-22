using TimesheetCalendar.Application.CalendarTimeLine;
using TimesheetCalendar.Application.ReservationSchedule.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TimesheetCalendar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarTimeLineService _calendarTimeLineService;

        public CalendarController(ICalendarTimeLineService calendarTimeLineService)
        {
            _calendarTimeLineService = calendarTimeLineService;
        }

        // ---- TODO Add User Identity and Fill The AppSession for filters ----

        [HttpGet("GetTimeLine")]
        public ActionResult<Task<CalendarTimeLineDto>> GetTimeLine(DateTime date)
        {
            date = date.AddMinutes(1); //TODO fix this, if user did not pass time.
            return Ok(_calendarTimeLineService.GetAvailbaleTimesForReserve(date));
        }
    }
}
