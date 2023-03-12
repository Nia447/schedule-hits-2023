using Schedule.Data.Models.DTO;
using Schedule.Data.Models;
using Schedule.Data;

namespace Schedule.Services
{
    public interface ISubjectAdminService
    {
        Task<bool> CreateSubject(SubjectCreateDto subjectCreateDto);
        Task<bool> DeleteSubject(Guid id);
        Task<bool> ChangeSubjectParams(Guid id, SubjectCreateDto subjectCreateDto);
        Task<bool> IsSubjectExist(SubjectCreateDto subjectCreateDto);
        Task<bool> IsSubjectExist(Guid id);
    }

    public class SubjectAdminService : ISubjectAdminService
    {
        private readonly ScheduleDbContext _context;
        public SubjectAdminService(ScheduleDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ChangeSubjectParams(Guid id, SubjectCreateDto subjectCreateDto)
        {
            _context.Subjects.First(x => x.Id == id).Name = subjectCreateDto.Name;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CreateSubject(SubjectCreateDto subjectCreateDto)
        {
            _context.Subjects.Add(new Subject()
            {
                Id = Guid.NewGuid(),
                Name = subjectCreateDto.Name
            });

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteSubject(Guid id)
        {
            _context.Subjects.Remove(_context.Subjects.First(x => x.Id == id));

            await _context.SaveChangesAsync();

            return true;
        }

        public Task<bool> IsSubjectExist(SubjectCreateDto subjectCreateDto)
        {
            return Task.FromResult(_context.Subjects.FirstOrDefault(x => x.Name == subjectCreateDto.Name) != null);
        }

        public Task<bool> IsSubjectExist(Guid id)
        {
            return Task.FromResult(_context.Subjects.FirstOrDefault(x => x.Id == id) != null);
        }
    }
}
