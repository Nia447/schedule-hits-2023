using Schedule.Data.Models.DTO;
using Schedule.Data.Models;
using Schedule.Data;

namespace Schedule.Services
{
    public interface IAudienceAdminService
    {
        Task<bool> CreateAudience(AudienceCreateDto audienceCreateDto);
        Task<bool> DeleteAudience(Guid id);
        Task<bool> ChangeAudiencepParams(Guid id, AudienceCreateDto audienceCreateDto);
        Task<bool> IsAudienceExist(AudienceCreateDto audienceCreateDto);
        Task<bool> IsAudienceExist(Guid id);
    }

    public class AudienceAdminService : IAudienceAdminService
    {
        private readonly ScheduleDbContext _context;
        public AudienceAdminService(ScheduleDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ChangeAudiencepParams(Guid id, AudienceCreateDto audienceCreateDto)
        {
            _context.Audiences.First(x => x.Id == id).Number = audienceCreateDto.Number;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CreateAudience(AudienceCreateDto audienceCreateDto)
        {
            _context.Audiences.Add(new Audience()
            {
                Id = Guid.NewGuid(),
                Number = audienceCreateDto.Number
            });

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAudience(Guid id)
        {
            _context.Audiences.Remove(_context.Audiences.First(x => x.Id == id));

            await _context.SaveChangesAsync();

            return true;
        }

        public Task<bool> IsAudienceExist(AudienceCreateDto audienceCreateDto)
        {
            return Task.FromResult(_context.Audiences.FirstOrDefault(x => x.Number == audienceCreateDto.Number) != null);
        }

        public Task<bool> IsAudienceExist(Guid id)
        {
            return Task.FromResult(_context.Audiences.FirstOrDefault(x => x.Id == id) != null);
        }
    }
}
