using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamsterWars2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hamsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Loves = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FavoriteFood = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalGames = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Defeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamsters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchesData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinnerId = table.Column<int>(type: "int", nullable: false),
                    LoserId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchesData", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hamsters",
                columns: new[] { "Id", "Age", "Defeats", "FavoriteFood", "ImageUrl", "Likes", "Loves", "Name", "TotalGames", "Wins" },
                values: new object[,]
                {
                    { 1, 1, 0, "Chinese food", "/Content/Images/hamster-1.jpg", 0, "World of Warcraft", "Scooby", 0, 0 },
                    { 2, 2, 0, "Broccoli", "/Content/Images/hamster-2.jpg", 0, "Rugby", "Shaggy", 0, 0 },
                    { 3, 3, 0, "Chicken and Rice", "/Content/Images/hamster-3.jpg", 0, "Football", "Fred", 0, 0 },
                    { 4, 1, 0, "Pizza", "/Content/Images/hamster-4.jpg", 0, "Skateboarding", "George", 0, 0 },
                    { 5, 1, 0, "Chinese food", "/Content/Images/hamster-5.jpg", 0, "Running", "Harry", 0, 0 },
                    { 6, 1, 0, "McDonalds", "/Content/Images/hamster-6.jpg", 0, "Golfing", "Ron", 0, 0 },
                    { 7, 1, 0, "Carrots", "/Content/Images/hamster-7.jpg", 0, "Sleeping", "Dumbledore", 0, 0 },
                    { 8, 1, 0, "Pasta", "/Content/Images/hamster-35.jpg", 0, "Liseberg", "Göran", 0, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hamsters");

            migrationBuilder.DropTable(
                name: "MatchesData");
        }
    }
}
