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
        public ActionResult<PeriodScheduleDto> GetForGroup(Guid id)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_scheduleService.IsExitingGroup(id))
                return StatusCode(404);

            return _scheduleService.GetPeriodScheduleGroup(new DateTime(2023, 3, 13), new DateTime(2023,3,19), id);
        }

        [HttpGet("teacher/{id}")]
        public ActionResult<PeriodScheduleDto> GetForTeacher(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_scheduleService.IsExitingTeacher(id))
                return StatusCode(404);

            return _scheduleService.GetPeriodScheduleTeacher(new DateTime(2023, 3, 13), new DateTime(2023, 3, 19), id);
        }
    }
}