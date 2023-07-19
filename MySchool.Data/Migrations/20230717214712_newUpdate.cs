using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySchool.Data.Migrations
{
    public partial class newUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "studentId",
                table: "Examinations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_studentId",
                table: "Examinations",
                column: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Students_studentId",
                table: "Examinations",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Students_studentId",
                table: "Examinations");

            migrationBuilder.DropIndex(
                name: "IX_Examinations_studentId",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "studentId",
                table: "Examinations");
        }
    }
}
