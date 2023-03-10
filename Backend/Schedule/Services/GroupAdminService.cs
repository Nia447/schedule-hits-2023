using Schedule.Data.Models.DTO;
using Schedule.Data.Models;
using Schedule.Data;

namespace Schedule.Services
{
    public interface IGroupAdminService
    {
        Task<bool> CreateGroup(GroupCreateDto groupCreateDto);
        Task<bool> DeleteGroup(Guid id);
        Task<bool> ChangeGroupParams(Guid id, GroupCreateDto groupCreateDto);
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
        public async Task<bool> ChangeGroupParams(Guid id, GroupCreateDto groupCreateDto)
        {
            try
            {
                _context.Groups.First(x => x.Id == id).Number = groupCreateDto.Number;

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateGroup(GroupCreateDto groupCreateDto)
        {
            try
            {
                _context.Groups.Add(new Group()
                {
                    Id = Guid.NewGuid(),
                    Number = groupCreateDto.Number
                });

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteGroup(Guid id)
        {
            try
            {
                _context.Groups.Remove(_context.Groups.First(x => x.Id == id));

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
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
