using Microsoft.EntityFrameworkCore;
using TelegramBot.Domain.Entities;

namespace TelegramBot.Web.Infrastructure.Persistences
{
    public class AppDbContext : DbContext 
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Dialogue> Dialogues { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3301"),
                    Author = "Джордж Оруэлл",
                    Title = "1984",
                    Genre = "Антиутопия",
                    Description = "Классический роман о тоталитарном обществе будущего.",
                    Price = 319,
                    Slug = "1984-novyy-perevod-2918634"
                },
                new Book()
                {
                    Id = Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    Author = "Федор Достоевский",
                    Title = "Преступление и наказание",
                    Genre = "Роман",
                    Description = "История о нравственном выборе и искуплении.",
                    Price = 309,
                    Slug = "prestuplenie-i-nakazanie-2465295"
                },
                new Book()
                {
                    Id = Guid.Parse("21ec2020-3aea-4069-a2dd-08002b30309d"),
                    Author = "Джейн Остин",
                    Title = "Гордость и предубеждение",
                    Genre = "Роман",
                    Description = "Романтическая история в английском обществе XIX века.",
                    Price = 290,
                    Slug = "gordost-i-predubezhdenie-3072633"
                },
                new Book()
                {
                    Id = Guid.Parse("6f9619ff-8b86-d011-b42d-00cf4fc964ff"),
                    Author = "Артур Конан Дойл",
                    Title = "Приключения Шерлока Холмса",
                    Genre = "Детектив",
                    Description = "Сборник историй о знаменитом детективе.",
                    Price = 337,
                    Slug = "priklyucheniya-sherloka-holmsa-2925677"
                },
                new Book()
                {
                    Id = Guid.Parse("16fd2706-8baf-433b-82eb-8c7fada847da"),
                    Author = "Марк Твен",
                    Title = "Приключения Тома Сойера",
                    Genre = "Повесть",
                    Description = "История приключений мальчика в США XIX века.",
                    Price = 319,
                    Slug = "priklyucheniya-toma-soyera-il-v-galdyaeva-2952874"
                },
                new Book()
                {
                    Id = Guid.Parse("9a9b8c6e-5f60-4aeb-9445-ffad474fb3f2"),
                    Author = "Лев Толстой",
                    Title = "Война и мир",
                    Genre = "Эпопея",
                    Description = "Масштабный роман о судьбах людей на фоне войны.",
                    Price = 347,
                    Slug = "voyna-i-mir-kniga-1-tt-1-2-roman-2471823"
                });
        }
    }
}