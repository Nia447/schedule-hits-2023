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
            var lessons = _context.Lessons.Where(x => x.ChangeIdLesson == null && x.Group != null && x.Group.Id == id && (x.EndPeriodDate == null || dateFrom < x.EndPeriodDate || dateTo > x.StartPeriodDate)).OrderBy(x => x.Day);
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
                        instance.Lessons.Add(_converterService.ToLessonDto(lesson));
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
                        result.Days[i].Lessons.Add(_converterService.ToLessonDto(lesson));
                    }
                }
            }

            return result;
        }

        public PeriodScheduleDto GetPeriodScheduleTeacher(DateTime dateFrom, DateTime dateTo, Guid id)
        {
            var lessons = _context.Lessons.Where(x => x.ChangeIdLesson == null && x.Teacher != null && x.Teacher.Id == id && (x.EndPeriodDate == null || dateFrom < x.EndPeriodDate || dateTo > x.StartPeriodDate)).OrderBy(x => x.Day);
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
                        instance.Lessons.Add(_converterService.ToLessonDto(lesson));
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
                        result.Days[i].Lessons.Add(_converterService.ToLessonDto(lesson));
                    }
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
            if ((Convert.ToInt16(day2) == 0 && day1 == DayOfTheWeek.Saturday) || Convert.ToInt16(day1) == Convert.ToInt16(day2 + 1))
                return true;
            return false;
        }
    }
}
