using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TelegramBot.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dialogues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    Length = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dialogues", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "Price", "Slug", "Title" },
                values: new object[,]
                {
                    { new Guid("16fd2706-8baf-433b-82eb-8c7fada847da"), "Марк Твен", "История приключений мальчика в США XIX века.", "Повесть", 319m, "priklyucheniya-toma-soyera-il-v-galdyaeva-2952874", "Приключения Тома Сойера" },
                    { new Guid("21ec2020-3aea-4069-a2dd-08002b30309d"), "Джейн Остин", "Романтическая история в английском обществе XIX века.", "Роман", 290m, "gordost-i-predubezhdenie-3072633", "Гордость и предубеждение" },
                    { new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"), "Джордж Оруэлл", "Классический роман о тоталитарном обществе будущего.", "Антиутопия", 319m, "1984-novyy-perevod-2918634", "1984" },
                    { new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"), "Артур Конан Дойл", "Сборник историй о знаменитом детективе.", "Детектив", 337m, "priklyucheniya-sherloka-holmsa-2925677", "Приключения Шерлока Холмса" },
                    { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), "Федор Достоевский", "История о нравственном выборе и искуплении.", "Роман", 309m, "prestuplenie-i-nakazanie-2465295", "Преступление и наказание" },
                    { new Guid("9a9b8c6e-5f60-4aeb-9445-ffad474fb3f2"), "Лев Толстой", "Масштабный роман о судьбах людей на фоне войны.", "Эпопея", 347m, "voyna-i-mir-kniga-1-tt-1-2-roman-2471823", "Война и мир" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Dialogues");
        }
    }
}
