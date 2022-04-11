using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tutor4MeApi.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timeslots_Module_ModuleId",
                table: "Timeslots");

            migrationBuilder.DropForeignKey(
                name: "FK_TutoredModule_Module_ModuleId",
                table: "TutoredModule");

            migrationBuilder.DropForeignKey(
                name: "FK_TutoredModule_Tutors_TutorId",
                table: "TutoredModule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TutoredModule",
                table: "TutoredModule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Module",
                table: "Module");

            migrationBuilder.RenameTable(
                name: "TutoredModule",
                newName: "TutoredModules");

            migrationBuilder.RenameTable(
                name: "Module",
                newName: "Modules");

            migrationBuilder.RenameIndex(
                name: "IX_TutoredModule_ModuleId",
                table: "TutoredModules",
                newName: "IX_TutoredModules_ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TutoredModules",
                table: "TutoredModules",
                columns: new[] { "TutorId", "ModuleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modules",
                table: "Modules",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeslots_Modules_ModuleId",
                table: "Timeslots",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TutoredModules_Modules_ModuleId",
                table: "TutoredModules",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TutoredModules_Tutors_TutorId",
                table: "TutoredModules",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "TutordId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timeslots_Modules_ModuleId",
                table: "Timeslots");

            migrationBuilder.DropForeignKey(
                name: "FK_TutoredModules_Modules_ModuleId",
                table: "TutoredModules");

            migrationBuilder.DropForeignKey(
                name: "FK_TutoredModules_Tutors_TutorId",
                table: "TutoredModules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TutoredModules",
                table: "TutoredModules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modules",
                table: "Modules");

            migrationBuilder.RenameTable(
                name: "TutoredModules",
                newName: "TutoredModule");

            migrationBuilder.RenameTable(
                name: "Modules",
                newName: "Module");

            migrationBuilder.RenameIndex(
                name: "IX_TutoredModules_ModuleId",
                table: "TutoredModule",
                newName: "IX_TutoredModule_ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TutoredModule",
                table: "TutoredModule",
                columns: new[] { "TutorId", "ModuleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Module",
                table: "Module",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeslots_Module_ModuleId",
                table: "Timeslots",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TutoredModule_Module_ModuleId",
                table: "TutoredModule",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TutoredModule_Tutors_TutorId",
                table: "TutoredModule",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "TutordId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
