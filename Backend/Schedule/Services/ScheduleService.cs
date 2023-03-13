using Schedule.Data;
using Schedule.Data.Models;
using Schedule.Data.Models.DTO;

namespace Schedule.Services
{
    public interface IScheduleService
    {
        PeriodScheduleDto GetPeriodScheduleGroup(DateTime dateFrom, DateTime dateTo, Guid id);
        PeriodScheduleDto GetPeriodScheduleTeacher(DateTime dateFrom, DateTime dateTo, Guid id);
        bool IsExitingGroup(Guid id);
        bool IsExitingTeacher(Guid id);
    }

    public class ScheduleService: IScheduleService
    {
        private ScheduleDbContext _context;
        private IConverterService _converterService;

        public ScheduleService(ScheduleDbContext context, IConverterService converterService)
        {
            _context = context;
            _converterService = converterService;
        }

        public PeriodScheduleDto GetPeriodScheduleGroup(DateTime dateFrom, DateTime dateTo, Guid id)
        {
            var lessons = _context.Lessons.Where(x => x.GroupId != null && x.GroupId == id && (x.EndPeriodDate == null || dateFrom < x.EndPeriodDate || dateTo > x.StartPeriodDate)).OrderBy(x => x.Day);
            PeriodScheduleDto result = new();
            List<Guid> ExceptionalGuidLessons = new();

            for (DateTime day = dateFrom; day <= dateTo; day = day.AddDays(1))
            {
                var instance = new DailyScheduleDto
                {
                    Date = DateOnly.FromDateTime(day)
                };

                foreach (var lesson in lessons)
                {
                    if (lesson.StartPeriodDate < day && day < lesson.EndPeriodDate && IsEqualDayOfTheWeek(lesson.Day, day.DayOfWeek))
                    {
                        instance.Lessons.Add(ToLessonDto(lesson));
                        ExceptionalGuidLessons.Add(lesson.Id);
                    }
                }

                result.Days.Add(instance);
            }

            int i = 0;
            for (DateTime day = dateFrom; day <= dateTo; day = day.AddDays(1), i++)
            {

                foreach (var lesson in lessons)
                {
                    if (!ExceptionalGuidLessons.Contains(lesson.Id) && lesson.StartPeriodDate < day && day < lesson.EndPeriodDate && IsEqualDayOfTheWeek(lesson.Day, day.DayOfWeek))
                    {
                        result.Days[i].Lessons.Add(ToLessonDto(lesson));
                    }
                }
            }

            foreach (var daily in result.Days)
            {
                foreach (LessonDto lesson in daily.Lessons)
                {
                    lesson.Subject.Name = _context.Subjects.Find(lesson.Subject.Id).Name;
                    lesson.Teacher.FullName = _context.Teachers.Find(lesson.Teacher.Id).FullName;
                    lesson.Audience.Number = _context.Audiences.Find(lesson.Audience.Id).Number;
                    lesson.Group.Number = _context.Groups.Find(lesson.Group.Id).Number;
                }
            }

            return result;
        }

        public PeriodScheduleDto GetPeriodScheduleTeacher(DateTime dateFrom, DateTime dateTo, Guid id)
        {
            var lessons = _context.Lessons.Where(x => x.TeacherId != null && x.TeacherId == id && (x.EndPeriodDate == null || dateFrom < x.EndPeriodDate || dateTo > x.StartPeriodDate)).OrderBy(x => x.Day);
            PeriodScheduleDto result = new();
            List<Guid> ExceptionalGuidLessons = new();

            for (DateTime day = dateFrom; day <= dateTo; day = day.AddDays(1))
            {
                var instance = new DailyScheduleDto
                {
                    Date = DateOnly.FromDateTime(day)
                };

                foreach (var lesson in lessons)
                {
                    if (lesson.StartPeriodDate < day && day < lesson.EndPeriodDate && IsEqualDayOfTheWeek(lesson.Day, day.DayOfWeek))
                    {
                        instance.Lessons.Add(ToLessonDto(lesson));
                        ExceptionalGuidLessons.Add(lesson.Id);
                    }
                }

                result.Days.Add(instance);
            }

            int i = 0;
            for (DateTime day = dateFrom; day <= dateTo; day = day.AddDays(1), i++)
            {
                foreach (var lesson in lessons)
                {
                    if (!ExceptionalGuidLessons.Contains(lesson.Id) && lesson.StartPeriodDate < day && day < lesson.EndPeriodDate && IsEqualDayOfTheWeek(lesson.Day, day.DayOfWeek))
                    {
                        result.Days[i].Lessons.Add(ToLessonDto(lesson));
                    }
                }
            }

            foreach (var daily in result.Days)
            {
                foreach (LessonDto lesson in daily.Lessons)
                {
                    lesson.Subject.Name = _context.Subjects.Find(lesson.Subject.Id).Name;
                    lesson.Teacher.FullName = _context.Teachers.Find(lesson.Teacher.Id).FullName;
                    lesson.Audience.Number = _context.Audiences.Find(lesson.Audience.Id).Number;
                    lesson.Group.Number = _context.Groups.Find(lesson.Group.Id).Number;
                }
            }

            return result;
        }

        public bool IsExitingGroup(Guid id)
        {
            if (_context.Groups.FirstOrDefault(x => x.Id == id) != null)
                return true;
            return false;
        }

        public bool IsExitingTeacher(Guid id)
        {
            if (_context.Teachers.FirstOrDefault(x => x.Id == id) != null)
                return true;
            return false;
        }

        private bool IsEqualDayOfTheWeek(DayOfTheWeek? day1, DayOfWeek day2)
        {
            if ((Convert.ToInt16(day2) == 0 && day1 == DayOfTheWeek.Saturday) || Convert.ToInt16(day1) == Convert.ToInt16(day2 - 1))
                return true;
            return false;
        }

        private LessonDto ToLessonDto(Lesson lesson)
        {
            Guid? subjectId = lesson.SubjectId;
            Guid? groupId = lesson.GroupId;
            Guid? teacherId = lesson.TeacherId;
            Guid? audienceId = lesson.AudienceId;
            return new LessonDto
            {
                Id = lesson.Id,
                NumberLesson = (NumberLesson)lesson.NumberLesson,
                Day = (DayOfTheWeek)lesson.Day,
                Type = (TypeLesson)lesson.Type,
                StartPeriodDate = (DateTime)lesson.StartPeriodDate,
                EndPeriodDate = (DateTime)lesson.EndPeriodDate,
                Subject = new SubjectDto
                {
                    Id = (Guid)subjectId,
                },
                Group = new GroupDto
                {
                    Id = (Guid)groupId,
                },
                Teacher = new TeacherDto
                {
                    Id = (Guid)teacherId,
                },
                Audience = new AudienceDto
                {
                    Id = (Guid)audienceId,
                }
            };
        }

        private async Task<SubjectDto> ToSubjectDto(Guid? id)
        {
            var subject = await _context.Subjects.FindAsync(id);

            if (subject == null)
            {
                return new SubjectDto
                {
                    Id = Guid.NewGuid(),
                    Name = "null"
                };
            }

            return new SubjectDto
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }

        private async Task<GroupDto> ToGroupDto(Guid? id)
        {
            var group = await _context.Groups.FindAsync(id);

            if (group == null)
            {
                return new GroupDto
                {
                    Id = Guid.NewGuid(),
                    Number = "null",
                };
            }
            return new GroupDto
            {
                Id = group.Id,
                Number = group.Number
            };
        }

        private async Task<TeacherDto> ToTeacherDto(Guid? id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return new TeacherDto { Id = Guid.NewGuid(), FullName = "null" };
            }
            return new TeacherDto
            {
                Id = teacher.Id,
                FullName = teacher.FullName
            };
        }

        private async Task<AudienceDto> ToAudienceDto(Guid? id)
        {
            var audience = await _context.Audiences.FindAsync(id);

            if (audience == null)
            {
                return new AudienceDto { Id = Guid.NewGuid(), Number = "null" };
            }
            return new AudienceDto
            {
                Id = audience.Id,
                Number = audience.Number
            };
        }
    }
}
