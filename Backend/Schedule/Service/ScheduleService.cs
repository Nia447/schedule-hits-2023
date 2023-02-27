using Schedule.Data;
using Schedule.Data.Models.DTO;

namespace Schedule.Service
{
    public interface IScheduleService
    {
        WeeklyScheduleDto GetWeeklyScheduleGroup(Guid id);
        WeeklyScheduleDto GetWeeklyScheduleTeacher(Guid id);
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

        public WeeklyScheduleDto GetWeeklyScheduleGroup(Guid id)
        {
            return null;
        }

        public WeeklyScheduleDto GetWeeklyScheduleTeacher(Guid id)
        {
            return null;
        }
    }
}
