﻿using Schedule.Data;
using Schedule.Data.Models;
using Schedule.Data.Models.DTO;

namespace Schedule.Services
{
    public interface IConverterService
    {
        Task<LessonDto> ToLessonDto(Lesson lesson);
    }

    public class ConverterService: IConverterService
    {
        ScheduleDbContext _context;

        public ConverterService (ScheduleDbContext context)
        {
            _context = context;
        }

        public Task<LessonDto> ToLessonDto(Lesson lesson)
        {
            return Task.FromResult(new LessonDto
            {
                Id = lesson.Id,
                NumberLesson = (NumberLesson)lesson.NumberLesson,
                Day = (DayOfTheWeek)lesson.Day,
                Type = (TypeLesson)lesson.Type,
                StartPeriodDate = (DateTime)lesson.StartPeriodDate,
                EndPeriodDate = (DateTime)lesson.EndPeriodDate,
                Subject = ToSubjectDto(lesson.SubjectId),
                Group = ToGroupDto(lesson.GroupId),
                Teacher = ToTeacherDto(lesson.TeacherId),
                Audience = ToAudienceDto(lesson.AudienceId)
            });
        }

        public SubjectDto ToSubjectDto(Guid? id)
        {
            var subject = _context.Subjects.Find(id);

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

        public GroupDto ToGroupDto(Guid? id)
        {
            var group = _context.Groups.Find(id);

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

        public TeacherDto ToTeacherDto(Guid? id)
        {
            var teacher = _context.Teachers.Find(id);

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

        public AudienceDto ToAudienceDto(Guid? id)
        {
            var audience = _context.Audiences.Find(id);

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
