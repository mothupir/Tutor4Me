using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tutor4MeApi.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ratings_TutorId",
                table: "Ratings",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Tutors_TutorId",
                table: "Ratings",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Tutors_TutorId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_TutorId",
                table: "Ratings");
        }
    }
}
