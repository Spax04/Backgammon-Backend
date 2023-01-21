using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backgammon_Backend.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Started = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumOfGames = table.Column<int>(type: "int", nullable: false),
                    NumOfWins = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "NickName", "Password", "PhotoFileName" },
                values: new object[] { new Guid("02b70d47-b43e-4a63-a276-bebdf3cf051a"), "gotlib14@gmail.com", "Shasha", "Ww1020", "\\Assets\\Users\\AlexGotlibImg.jpeg" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "NickName", "Password", "PhotoFileName" },
                values: new object[] { new Guid("24e46eab-12fe-43ff-8793-bece2d973d97"), "margolinavigail@gmail.com", "Aviguli", "Avigail227", "\\Assets\\Users\\AvigailMargolinImg.jpeg" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "NickName", "Password", "PhotoFileName" },
                values: new object[] { new Guid("4a083d8d-da7a-4f70-b4a3-4f9a7b4e88c4"), "danielbedrack@gmail.com", "Danik", "Daniel227", "\\Assets\\Users\\DanielBedrackImg.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameId",
                table: "Players",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
