using Microsoft.AspNetCore.Mvc;
using Schedule.Data.Models.DTO;
using Schedule.Services;

namespace Schedule.Controllers
{
	[ApiController]
	[Route("api/schedule")]
	public class SelectionController : ControllerBase
	{
		private readonly ISelectionService _selectionService;

		public SelectionController(ISelectionService selectionService)
		{
			_selectionService = selectionService;
		}

		[HttpGet("teachers")]
		public ActionResult<TeacherListDto> GetTeachersList(string? searchStr = "")
        {
			return _selectionService.SelectTeachersBySearchStr(searchStr);
        }

		[HttpGet("groups")]
		public ActionResult<GroupListDto> GetGroupsList(string? searchStr = "")
		{
			return _selectionService.SelectGroupsBySearchStr(searchStr);
		}
		
		[HttpGet("audieces")]
		public ActionResult<AudienceListDto> GetAudiencesList(string? searchStr = "")
		{
			return _selectionService.SelectAudienceBySearchStr(searchStr);
		}

		[HttpGet("subjects")]
		public ActionResult<SubjectListDto> GetSubjctsList(string? searchStr = "")
		{
			return _selectionService.SelectSubjectBySearchStr(searchStr);
		}
	}
}
