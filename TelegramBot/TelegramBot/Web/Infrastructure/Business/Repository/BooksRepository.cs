using Microsoft.EntityFrameworkCore;
using TelegramBot.Domain.Entities;
using TelegramBot.Domain.Interfaces.Repositories;
using TelegramBot.Shared.Constants;
using TelegramBot.Web.Infrastructure.Persistences;

namespace TelegramBot.Web.Infrastructure.Business.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppDbContext _appDbContext;

        public BooksRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Book>> GetRandomAsync()
        {
            return await _appDbContext.Books
                .OrderBy(b => EF.Functions.Random())
                .Take(BookDefaults.Count)
                .ToListAsync();
        }
    }
}
