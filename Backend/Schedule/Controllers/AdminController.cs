using Microsoft.AspNetCore.Mvc;
using Schedule.Data.Models.DTO;
using Schedule.Services;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("api/schedule")]
    public class AdminController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public AdminController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        #region Lesson
        [HttpPost("lesson")]
        public async Task<IActionResult> PostLesson([FromBody] LessonCreateDto lessonCreateDto)
        {
            if (!ModelState.IsValid || _lessonService.IsCorrectLesson(lessonCreateDto).Result)
                return BadRequest();

            if (_lessonService.IsLessonExist(lessonCreateDto).Result)
                return StatusCode(409);

            await _lessonService.TryCreateLessonAsync(lessonCreateDto);

            return Ok();
        }

        [HttpDelete("lesson/{id}")]
        public async Task<IActionResult> DeleteLesson(Guid id)
        {
            if (!_lessonService.IsLessonExist(id).Result)
                return StatusCode(404);

            await _lessonService.TryDeleteLessonAsync(id);

            return Ok();
        }

        [HttpPut("lesson/{id}")]
        public async Task<IActionResult> ChangeLesson([FromBody] LessonEditDto lessonEditDto, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_lessonService.IsLessonExist(id).Result)
                return StatusCode(404);

            if (lessonEditDto.DeletePrevLesson)
            {
                await _lessonService.TryChangeLessonAsync(id, lessonEditDto);

                return Ok();
            }
            else
            {
                if (_lessonService.IsAdditionalLessonExist(lessonEditDto).Result)
                    return StatusCode(409);

                await _lessonService.TryAddAdditionalLessonAsync(id, lessonEditDto);

                return Ok();
            }
        }
        #endregion
    }
}