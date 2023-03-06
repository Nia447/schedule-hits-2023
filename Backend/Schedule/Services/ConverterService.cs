using Schedule.Data;
using Schedule.Data.Models;
using Schedule.Data.Models.DTO;

namespace Schedule.Services
{
    public interface IConverterService
    {
        LessonDto ToLessonDto(Lesson lesson);
    }

    public class ConverterService: IConverterService
    {
        public LessonDto ToLessonDto(Lesson lesson)
        {
            return new LessonDto
            {
                Id = lesson.Id,
                NumberLesson = (NumberLesson)lesson.NumberLesson,
                Day = (DayOfTheWeek)lesson.Day,
                Type = (TypeLesson)lesson.Type,
                StartPeriodDate = (DateTime)lesson.StartPeriodDate,
                EndPeriodDate = (DateTime)lesson.EndPeriodDate,
                Subject = ToSubjectDto(lesson.Subject),
                Group = ToGroupDto(lesson.Group),
                Teacher = ToTeacherDto(lesson.Teacher),
                Audience = ToAudienceDto(lesson.Audience)
            };
        }

        public SubjectDto ToSubjectDto(Subject subject)
        {
            return new SubjectDto
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }

        public GroupDto ToGroupDto(Group group)
        {
            return new GroupDto
            {
                Id = group.Id,
                Number = group.Number
            };
        }

        public TeacherDto ToTeacherDto(Teacher teacher)
        {
            return new TeacherDto
            {
                Id = teacher.Id,
                FullName = teacher.FullName
            };
        }

        public AudienceDto ToAudienceDto(Audience audience)
        {
            return new AudienceDto
            {
                Id = audience.Id,
                Number = audience.Number
            };
        }
    }
}
