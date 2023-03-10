using Schedule.Data;
using Schedule.Data.Models;
using Schedule.Data.Models.DTO;

namespace Schedule.Services
{
    public interface ILessonAdminService
    {
        Task<bool> TryCreateLessonAsync(LessonCreateDto lessonCreateDto);
        Task<bool> TryDeleteLessonAsync(Guid id);
        Task<bool> TryChangeLessonAsync(Guid id, LessonEditDto lessonEditDto);
        Task<bool> TryAddAdditionalLessonAsync(Guid id, LessonEditDto lessonEditDto);
        Task<bool> IsLessonExist(LessonCreateDto lessonCreateDto);
        Task<bool> IsLessonExist(Guid id);
        Task<bool> IsCorrectLesson(LessonCreateDto lessonCreateDto);
        Task<bool> IsAdditionalLessonExist(LessonEditDto lessonEditDto);
    }
    public class LessonAdminService: ILessonAdminService
    {
        private readonly ScheduleDbContext _context;

        public LessonAdminService(ScheduleDbContext context)
        {
            _context = context;
        }

        public async Task<bool> TryCreateLessonAsync(LessonCreateDto lessonCreateDto)
        {
            try
            {
                _context.Add(new Lesson
                {
                    Id = Guid.NewGuid(),
                    NumberLesson = lessonCreateDto.NumberLesson,
                    Day = lessonCreateDto.Day,
                    Type = lessonCreateDto.Type,
                    StartPeriodDate = lessonCreateDto.StartPeriodDate,
                    EndPeriodDate = lessonCreateDto.EndPeriodDate,
                    Group = _context.Groups.First(x => x.Id == lessonCreateDto.IdGroup),
                    Subject = _context.Subjects.First(x => x.Id == lessonCreateDto.IdSubject),
                    Teacher = _context.Teachers.First(x => x.Id == lessonCreateDto.IdTeacher),
                    Audience = _context.Audiences.First(x => x.Id == lessonCreateDto.IdAudience),
                });

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryDeleteLessonAsync(Guid id)
        {
            try
            {
                _context.Remove(_context.Lessons.First(x => x.Id == id));
                
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryChangeLessonAsync(Guid id, LessonEditDto lessonEditDto)
        {
            try
            {
                var lesson = _context.Lessons.First(x => x.Id == id);

                lesson.NumberLesson = lessonEditDto.NumberLesson;
                lesson.Day = lessonEditDto.Day;
                lesson.Type = lessonEditDto.Type;
                lesson.StartPeriodDate = lessonEditDto.StartPeriodDate;
                lesson.EndPeriodDate = lessonEditDto.EndPeriodDate;
                if (lessonEditDto.IdGroup != lesson.Group.Id)
                    lesson.Group = _context.Groups.First(x => x.Id == lessonEditDto.IdGroup);
                if (lessonEditDto.IdTeacher != lesson.Teacher.Id)
                    lesson.Teacher = _context.Teachers.First(x => x.Id == lessonEditDto.IdTeacher);
                if (lessonEditDto.IdSubject != lesson.Subject.Id)
                    lesson.Subject = _context.Subjects.First(x => x.Id == lessonEditDto.IdSubject);
                if (lessonEditDto.IdAudience != lesson.Audience.Id)
                    lesson.Audience = _context.Audiences.First(x => x.Id == lessonEditDto.IdAudience);

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryAddAdditionalLessonAsync(Guid id, LessonEditDto lessonEditDto)
        {
            try
            {
                _context.Add(new Lesson
                {
                    Id = Guid.NewGuid(),
                    ChangeIdLesson = lessonEditDto.Id,
                    NumberLesson = lessonEditDto.NumberLesson,
                    Day = lessonEditDto.Day,
                    Type = lessonEditDto.Type,
                    StartPeriodDate = lessonEditDto.StartPeriodDate,
                    EndPeriodDate = lessonEditDto.EndPeriodDate,
                    Group = _context.Groups.First(x => x.Id == lessonEditDto.IdGroup),
                    Subject = _context.Subjects.First(x => x.Id == lessonEditDto.IdSubject),
                    Teacher = _context.Teachers.First(x => x.Id == lessonEditDto.IdTeacher),
                    Audience = _context.Audiences.First(x => x.Id == lessonEditDto.IdAudience),
                });

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<bool> IsLessonExist(LessonCreateDto lessonCreateDto)
        {
            var result = _context.Lessons.FirstOrDefault(x => x.NumberLesson == lessonCreateDto.NumberLesson &&
                                                            x.Day == lessonCreateDto.Day &&
                                                            x.Type == lessonCreateDto.Type &&
                                                            ((x.EndPeriodDate > lessonCreateDto.StartPeriodDate &&
                                                            x.StartPeriodDate < lessonCreateDto.StartPeriodDate) ||
                                                            (x.StartPeriodDate < lessonCreateDto.EndPeriodDate &&
                                                            x.EndPeriodDate > lessonCreateDto.EndPeriodDate) ||
                                                            (x.StartPeriodDate < lessonCreateDto.EndPeriodDate &&
                                                            x.EndPeriodDate == null) ||
                                                            (x.EndPeriodDate > lessonCreateDto.StartPeriodDate) &&
                                                            lessonCreateDto.EndPeriodDate == null) &&
                                                            (x.Group.Id == lessonCreateDto.IdGroup ||
                                                            x.Teacher.Id == lessonCreateDto.IdTeacher ||
                                                            x.Audience.Id == lessonCreateDto.IdAudience));
            if (result != null)
                return Task.FromResult(true);
            return Task.FromResult(false);
        }

        public Task<bool> IsLessonExist(Guid id)
        {
            return Task.FromResult(_context.Lessons.FirstOrDefault(x => x.Id == id) != null ? true : false);
        }

        public Task<bool> IsCorrectLesson(LessonCreateDto lessonCreateDto)
        {
            return null;
        }

        public Task<bool> IsAdditionalLessonExist(LessonEditDto lessonEditDto)
        {
            var result = _context.Lessons.FirstOrDefault(x => x.ChangeIdLesson == lessonEditDto.Id &&
                                                            ((x.EndPeriodDate > lessonEditDto.StartPeriodDate &&
                                                            x.StartPeriodDate < lessonEditDto.StartPeriodDate) ||
                                                            (x.StartPeriodDate < lessonEditDto.EndPeriodDate &&
                                                            x.EndPeriodDate > lessonEditDto.EndPeriodDate) ||
                                                            (x.StartPeriodDate < lessonEditDto.EndPeriodDate &&
                                                            x.EndPeriodDate == null) ||
                                                            (x.EndPeriodDate > lessonEditDto.StartPeriodDate) &&
                                                            lessonEditDto.EndPeriodDate == null));
            if (result == null)
                return Task.FromResult(true);
            return Task.FromResult(false);
        }
    }
}
