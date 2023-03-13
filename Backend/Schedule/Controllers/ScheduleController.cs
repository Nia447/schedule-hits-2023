using Microsoft.AspNetCore.Mvc;
using Schedule.Data.Models.DTO;
using Schedule.Services;

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
        public ActionResult<PeriodScheduleDto> GetForGroup(Guid id, [FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_scheduleService.IsExitingGroup(id))
                return StatusCode(404);

            return new JsonResult(_scheduleService.GetPeriodScheduleGroup(dateFrom, dateTo, id));
        }

        [HttpGet("teacher/{id}")]
        public ActionResult<PeriodScheduleDto> GetForTeacher(Guid id, [FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_scheduleService.IsExitingTeacher(id))
                return StatusCode(404);

            return new JsonResult(_scheduleService.GetPeriodScheduleTeacher(dateFrom, dateTo, id));
        }
    }
}