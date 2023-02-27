using Microsoft.AspNetCore.Mvc;
using Schedule.Data.Models.DTO;
using Schedule.Service;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("api/schedule")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("group/{id}")]
        public ActionResult<WeeklyScheduleDto> GetForGroup(Guid id)
        {
            return new JsonResult(_scheduleService.GetWeeklyScheduleGroup(id));
        }

        [HttpGet("teacher/{id}")]
        public ActionResult<WeeklyScheduleDto> GetForTeacher(Guid id)
        {
            return new JsonResult(_scheduleService.GetWeeklyScheduleTeacher(id));
        }
    }
}