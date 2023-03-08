using Schedule.Data.Models.DTO;
using Schedule.Data.Models;
using Schedule.Data;

namespace Schedule.Services
{
    public interface ISubjectAdminService
    {
        Task CreateSubject(SubjectCreateDto subjectCreateDto);
        Task DeleteSubject(Guid id);
        Task ChangeSubjectParams(Guid id, SubjectCreateDto subjectCreateDto);
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

        public Task ChangeSubjectParams(Guid id, SubjectCreateDto subjectCreateDto)
        {
            _context.Subjects.First(x => x.Id == id).Name = subjectCreateDto.Name;

            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public Task CreateSubject(SubjectCreateDto subjectCreateDto)
        {
            _context.Subjects.AddAsync(new Subject()
            {
                Id = Guid.NewGuid(),
                Name = subjectCreateDto.Name
            });

            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public Task DeleteSubject(Guid id)
        {
            _context.Subjects.Remove(_context.Subjects.First(x => x.Id == id));

            _context.SaveChangesAsync();

            return Task.CompletedTask;
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
