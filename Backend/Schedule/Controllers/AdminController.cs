using Microsoft.AspNetCore.Mvc;
using Schedule.Data.Models.DTO;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("api")]
    public class AdminController : ControllerBase
    {
        [HttpPost("createLesson")]
        public ActionResult<LessonCreateDto> PostLesson()
        {
            return BadRequest("Can not create lesson");
        }

        /*[HttpDelete("deleteLesson")]
        public ActionResult<LessonCreateDto> DeleteLesson()
        {
            return BadRequest("Can not create lesson");
        }

        [HttpPut("changeLesson")]
        public ActionResult<LessonCreateDto> ChangeLesson()
        {
            return BadRequest("Can not create lesson");
        }

        [HttpPost("createGroup")]
        public ActionResult<LessonCreateDto> PostGroup()
        {
            return BadRequest("Can not create lesson");
        }

        [HttpDelete("deleteGroup")]
        public ActionResult<LessonCreateDto> DeleteGroup()
        {
            return BadRequest("Can not create lesson");
        }

        [HttpPost("createTeacher")]
        public ActionResult<LessonCreateDto> CreateTeacher()
        {
            return BadRequest("Can not create lesson");
        }

        [HttpDelete("deleteGroup")]
        public ActionResult<LessonCreateDto> DeleteTeacher()
        {
            return BadRequest("Can not create lesson");
        }

        [HttpPost("createAudience")]
        public ActionResult<LessonCreateDto> CreateAudience()
        {
            return BadRequest("Can not create lesson");
        }

        [HttpDelete("deleteAudience")]
        public ActionResult<LessonCreateDto> DeleteAudience()
        {
            return BadRequest("Can not create lesson");
        }*/
    }
}