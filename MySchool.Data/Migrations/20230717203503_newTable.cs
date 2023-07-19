using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySchool.Data.Migrations
{
    public partial class newTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Examinations_ExaminationId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "ExaminationId",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Examinations_ExaminationId",
                table: "Questions",
                column: "ExaminationId",
                principalTable: "Examinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Examinations_ExaminationId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "ExaminationId",
                table: "Questions",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Examinations_ExaminationId",
                table: "Questions",
                column: "ExaminationId",
                principalTable: "Examinations",
                principalColumn: "Id");
        }
    }
}
