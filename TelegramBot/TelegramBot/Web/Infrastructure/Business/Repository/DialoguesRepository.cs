using Microsoft.EntityFrameworkCore;
using TelegramBot.Domain.Entities;
using TelegramBot.Domain.Interfaces.Repositories;
using TelegramBot.Web.Infrastructure.Persistences;

namespace TelegramBot.Web.Infrastructure.Business.Repository
{
    public class DialoguesRepository : IDialoguesRepository
    {
        private readonly AppDbContext _appDbContext;

        public DialoguesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddRangeAsync(IEnumerable<Dialogue> dialogues)
        {
            await _appDbContext.Dialogues.AddRangeAsync(dialogues);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Dialogue>> GetByLengthAsync(int length, int tolerance)
        {
            return await _appDbContext.Dialogues
                .Where(d => d.Length >= length - tolerance && d.Length <= length + tolerance)
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync()
        {
            return await _appDbContext.Dialogues.AnyAsync();
        }
    }
}
