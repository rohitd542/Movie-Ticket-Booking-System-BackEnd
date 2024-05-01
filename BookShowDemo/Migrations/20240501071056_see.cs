using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveUrShowUsingCFA.Migrations
{
    public partial class see : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTicket_FindTicket_MovieId",
                table: "BookTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTicket_Registration_UserId",
                table: "BookTicket");

            migrationBuilder.DropIndex(
                name: "IX_BookTicket_MovieId",
                table: "BookTicket");

            migrationBuilder.DropIndex(
                name: "IX_BookTicket_UserId",
                table: "BookTicket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BookTicket_MovieId",
                table: "BookTicket",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTicket_UserId",
                table: "BookTicket",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTicket_FindTicket_MovieId",
                table: "BookTicket",
                column: "MovieId",
                principalTable: "FindTicket",
                principalColumn: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTicket_Registration_UserId",
                table: "BookTicket",
                column: "UserId",
                principalTable: "Registration",
                principalColumn: "userid");
        }
    }
}
