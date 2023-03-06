using Microsoft.AspNetCore.Mvc;
using Schedule.Data.Models.DTO;
using Schedule.Services;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("api/schedule")]
    public class AdminController : ControllerBase
    {
        private readonly IAudienceAdminService _audienceAdminService;
        private readonly IGroupAdminService _groupAdminService;
        private readonly ITeacherAdminService _teacherAdminService;
        private readonly ISubjectAdminService _subjectAdminService;

        public AdminController(
            IAudienceAdminService audienceAdminService,
            IGroupAdminService groupAdminService,
            ITeacherAdminService teacherAdminService,
            ISubjectAdminService subjectAdminService)
        {
            _audienceAdminService = audienceAdminService;
            _groupAdminService = groupAdminService;
            _teacherAdminService = teacherAdminService;
            _subjectAdminService = subjectAdminService;
        }

        #region Group
        [HttpPost("group")]
        public async Task<IActionResult> PostGroup([FromBody] GroupCreateDto groupCreateDto)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            if (_groupAdminService.IsGroupExist(groupCreateDto).Result)
                return StatusCode(409);

            await _groupAdminService.CreateGroup(groupCreateDto);

            return Ok();
        }

        [HttpDelete("group/{id}")]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            if(!_groupAdminService.IsGroupExist(id).Result)
                return StatusCode(404);

            await _groupAdminService.DeleteGroup(id);

            return Ok();
        }

        [HttpPut("group/{id}")]
        public async Task<IActionResult> CreateTeacher(Guid id, [FromBody] GroupCreateDto groupCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (!_groupAdminService.IsGroupExist(id).Result)
                return StatusCode(404);

            await _groupAdminService.ChangeGroupParams(id, groupCreateDto);

            return Ok();
        }
        #endregion
        #region Audience
        [HttpPost("audience")]
        public async Task<IActionResult> CreateAudience([FromBody] AudienceCreateDto audienceCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_audienceAdminService.IsAudienceExist(audienceCreateDto).Result)
                return StatusCode(409);

            await _audienceAdminService.CreateAudience(audienceCreateDto);

            return Ok();
        }

        [HttpDelete("audience/{id}")]
        public async Task<IActionResult> DeleteAudience(Guid id)
        {
            if (!_audienceAdminService.IsAudienceExist(id).Result)
                return StatusCode(404);

            await _audienceAdminService.DeleteAudience(id);

            return BadRequest("Can not create lesson");
        }

        [HttpPut("audience/{id}")]
        public async Task<IActionResult> ChangeAudience(Guid id, [FromBody] AudienceCreateDto audienceCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_audienceAdminService.IsAudienceExist(audienceCreateDto).Result)
                return StatusCode(409);

            await _audienceAdminService.ChangeAudiencepParams(id, audienceCreateDto);

            return Ok();
        }
        #endregion
        #region Subject
        [HttpPost("subject")]
        public async Task<IActionResult> CreateSubject([FromBody] SubjectCreateDto subjectCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_subjectAdminService.IsSubjectExist(subjectCreateDto).Result)
                return StatusCode(409);

            await _subjectAdminService.CreateSubject(subjectCreateDto);

            return Ok();
        }

        [HttpDelete("subject/{id}")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            if (!_subjectAdminService.IsSubjectExist(id).Result)
                return StatusCode(404);

            await _subjectAdminService.DeleteSubject(id);

            return BadRequest("Can not create lesson");
        }

        [HttpPut("subject/{id}")]
        public async Task<IActionResult> ChangeSubject(Guid id, [FromBody] SubjectCreateDto audienceCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_subjectAdminService.IsSubjectExist(audienceCreateDto).Result)
                return StatusCode(409);

            await _subjectAdminService.ChangeSubjectParams(id, audienceCreateDto);

            return Ok();
        }
        #endregion
        #region Teacher
        [HttpPost("teacher")]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherCreateDto teacherCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_teacherAdminService.IsTeacherExist(teacherCreateDto).Result)
                return StatusCode(409);

            await _teacherAdminService.CreateTeacher(teacherCreateDto);

            return Ok();
        }

        [HttpDelete("teacher/{id}")]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            if (!_teacherAdminService.IsTeacherExist(id).Result)
                return StatusCode(404);

            await _teacherAdminService.DeleteTeacher(id);

            return BadRequest("Can not create lesson");
        }

        [HttpPut("teacher/{id}")]
        public async Task<IActionResult> ChangeTeacher(Guid id, [FromBody] TeacherCreateDto teacherCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_teacherAdminService.IsTeacherExist(teacherCreateDto).Result)
                return StatusCode(409);

            await _teacherAdminService.ChangeTeacherParams(id, teacherCreateDto);

            return Ok();
        }
        #endregion
    }
}