using Schedule.Data.Models.DTO;
using Schedule.Data.Models;
using Schedule.Data;

namespace Schedule.Services
{
    public interface IGroupAdminService
    {
        Task CreateGroup(GroupCreateDto groupCreateDto);
        Task DeleteGroup(Guid id);
        Task ChangeGroupParams(Guid id, GroupCreateDto groupCreateDto);
        Task<bool> IsGroupExist(GroupCreateDto groupCreateDto);
        Task<bool> IsGroupExist(Guid id);
    }

    public class GroupAdminService : IGroupAdminService
    {
        private readonly ScheduleDbContext _context;
        public GroupAdminService(ScheduleDbContext context)
        {
            _context = context;
        }
        public Task ChangeGroupParams(Guid id, GroupCreateDto groupCreateDto)
        {
            _context.Groups.First(x => x.Id == id).Number = groupCreateDto.Number;

            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public Task CreateGroup(GroupCreateDto groupCreateDto)
        {
            _context.Groups.AddAsync(new Group()
            {
                Id = Guid.NewGuid(),
                Number = groupCreateDto.Number
            });

            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public Task DeleteGroup(Guid id)
        {
            _context.Groups.Remove(_context.Groups.First(x => x.Id == id));

            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public Task<bool> IsGroupExist(GroupCreateDto groupCreateDto)
        {
            return Task.FromResult(_context.Groups.FirstOrDefault(x => x.Number == groupCreateDto.Number) != null);
        }

        public Task<bool> IsGroupExist(Guid id)
        {
            return Task.FromResult(_context.Groups.FirstOrDefault(x => x.Id == id) != null);
        }
    }
}
