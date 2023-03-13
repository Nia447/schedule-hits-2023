using Schedule.Data.Models.DTO;
using Schedule.Data.Models;
using Schedule.Data;

namespace Schedule.Services
{
    public interface ISelectionService
    {
        TeacherListDto SelectTeachersBySearchStr(string searchStr = "");
        GroupListDto SelectGroupsBySearchStr(string searchStr = "");
        AudienceListDto SelectAudienceBySearchStr(string searchStr = "");
        SubjectListDto SelectSubjectBySearchStr(string searchStr = "");
        List<LessonDto> SelectLessons();
    }
    public class SelectionService : ISelectionService
    {
        private readonly ScheduleDbContext _context;
        private readonly IConverterService _converterService;
        public SelectionService(ScheduleDbContext context, IConverterService converterService)
        {
            _context = context;
            _converterService = converterService;
        }

        public GroupListDto SelectGroupsBySearchStr(string searchStr = "")
        {
            GroupListDto result = new();

            _context.Groups.First();

            foreach (var group in _context.Groups.Where(x => x.Number.Contains(searchStr)).OrderBy(x => x.Number))
            {
                GroupDto resultGroup = new()
                {
                    Id = group.Id,
                    Number = group.Number,
                };

                result.Groups.Add(resultGroup);
            }

            return result;
        }

        public TeacherListDto SelectTeachersBySearchStr(string searchStr = "")
        {
            TeacherListDto result = new();

            foreach (var teacher in _context.Teachers.Where(x => x.FullName.Contains(searchStr)).OrderBy(x => x.FullName))
            {
                TeacherDto resultTeacher = new()
                {
                    Id = teacher.Id,
                    FullName = teacher.FullName,
                };

                result.Teachers.Add(resultTeacher);
            }

            return result;
        }

        public AudienceListDto SelectAudienceBySearchStr(string searchStr = "")
        {
            AudienceListDto result = new();

            foreach (var audience in _context.Audiences.Where(x => x.Number.Contains(searchStr)).OrderBy(x => x.Number))
            {
                AudienceDto resultAudience = new()
                {
                    Id = audience.Id,
                    Number = audience.Number,
                };

                result.Audiences.Add(resultAudience);
            }

            return result;
        }

        public SubjectListDto SelectSubjectBySearchStr(string searchStr = "")
        {
            SubjectListDto result = new();

            foreach (var subject in _context.Subjects.Where(x => x.Name.Contains(searchStr)).OrderBy(x => x.Name))
            {
                SubjectDto resultAudience = new()
                {
                    Id = subject.Id,
                    Name = subject.Name,
                };

                result.Subjects.Add(resultAudience);
            }

            return result;
        }

        public List<LessonDto> SelectLessons()
        {
            List<LessonDto> result = new List<LessonDto>();

            List<Lesson> lessons = _context.Lessons.ToList();

            foreach (Lesson lesson in lessons)
            {
                result.Add(_converterService.ToLessonDto(lesson).Result);
            }

            return result;
        }
    }
}