using Schedule.Data.Models.DTO;
using Schedule.Data.Models;
using Schedule.Data;

namespace Schedule.Services
{
    public interface IAudienceAdminService
    {
        Task CreateAudience(AudienceCreateDto audienceCreateDto);
        Task DeleteAudience(Guid id);
        Task ChangeAudiencepParams(Guid id, AudienceCreateDto audienceCreateDto);
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
        public Task ChangeAudiencepParams(Guid id, AudienceCreateDto audienceCreateDto)
        {
            _context.Audiences.First(x => x.Id == id).Number = audienceCreateDto.Number;

            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public Task CreateAudience(AudienceCreateDto audienceCreateDto)
        {
            _context.Audiences.AddAsync(new Audience()
            {
                Id = Guid.NewGuid(),
                Number = audienceCreateDto.Number
            });

            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public Task DeleteAudience(Guid id)
        {
            _context.Audiences.Remove(_context.Audiences.First(x => x.Id == id));

            _context.SaveChangesAsync();

            return Task.CompletedTask;
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
