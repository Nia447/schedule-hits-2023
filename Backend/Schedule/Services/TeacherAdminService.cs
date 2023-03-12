using Schedule.Data.Models.DTO;
using Schedule.Data.Models;
using Schedule.Data;

namespace Schedule.Services
{
    public interface ITeacherAdminService
    {
        Task<bool> CreateTeacher(TeacherCreateDto teacherCreateDto);
        Task<bool> DeleteTeacher(Guid id);
        Task<bool> ChangeTeacherParams(Guid id, TeacherCreateDto teacherCreateDto);
        Task<bool> IsTeacherExist(TeacherCreateDto teacherCreateDto);
        Task<bool> IsTeacherExist(Guid id);
    }

    public class TeacherAdminService : ITeacherAdminService
    {
        private readonly ScheduleDbContext _context;
        public TeacherAdminService(ScheduleDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ChangeTeacherParams(Guid id, TeacherCreateDto teacherCreateDto)
        {
            _context.Teachers.First(x => x.Id == id).FullName = teacherCreateDto.FullName;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CreateTeacher(TeacherCreateDto teacherCreateDto)
        {
            _context.Teachers.Add(new Teacher()
            {
                Id = Guid.NewGuid(),
                FullName = teacherCreateDto.FullName
            });

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTeacher(Guid id)
        {
            _context.Teachers.Remove(_context.Teachers.First(x => x.Id == id));

            await _context.SaveChangesAsync();

            return true;
        }

        public Task<bool> IsTeacherExist(TeacherCreateDto teacherCreateDto)
        {
            return Task.FromResult(_context.Teachers.FirstOrDefault(x => x.FullName == teacherCreateDto.FullName) != null);
        }

        public Task<bool> IsTeacherExist(Guid id)
        {
            return Task.FromResult(_context.Teachers.FirstOrDefault(x => x.Id == id) != null);
        }
    }
}
