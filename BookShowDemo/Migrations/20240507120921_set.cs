using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveUrShowUsingCFA.Migrations
{
    public partial class set : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FindTicket",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Theatrename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moviename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    charges = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FindTicket", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    confirmpassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usertype = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Customer")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "BookTicket",
                columns: table => new
                {
                    Bookid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seatnum = table.Column<int>(type: "int", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTicket", x => x.Bookid);
                    table.ForeignKey(
                        name: "FK_BookTicket_FindTicket_MovieId",
                        column: x => x.MovieId,
                        principalTable: "FindTicket",
                        principalColumn: "MovieId");
                    table.ForeignKey(
                        name: "FK_BookTicket_Registration_UserId",
                        column: x => x.UserId,
                        principalTable: "Registration",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTicket_MovieId",
                table: "BookTicket",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTicket_UserId",
                table: "BookTicket",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTicket");

            migrationBuilder.DropTable(
                name: "FindTicket");

            migrationBuilder.DropTable(
                name: "Registration");
        }
    }
}
