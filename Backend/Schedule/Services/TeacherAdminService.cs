using Schedule.Data.Models.DTO;
using Schedule.Data.Models;
using Schedule.Data;

namespace Schedule.Services
{
    public interface ITeacherAdminService
    {
        Task CreateTeacher(TeacherCreateDto teacherCreateDto);
        Task DeleteTeacher(Guid id);
        Task ChangeTeacherParams(Guid id, TeacherCreateDto teacherCreateDto);
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
        public Task ChangeTeacherParams(Guid id, TeacherCreateDto teacherCreateDto)
        {
            _context.Teachers.First(x => x.Id == id).FullName = teacherCreateDto.FullName;

            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public Task CreateTeacher(TeacherCreateDto teacherCreateDto)
        {
            _context.Teachers.AddAsync(new Teacher()
            {
                Id = Guid.NewGuid(),
                FullName = teacherCreateDto.FullName
            });

            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public Task DeleteTeacher(Guid id)
        {
            _context.Teachers.Remove(_context.Teachers.First(x => x.Id == id));

            _context.SaveChangesAsync();

            return Task.CompletedTask;
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
