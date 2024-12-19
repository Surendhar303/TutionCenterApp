using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutionCenterApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department_Id",
                table: "Student");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentId",
                table: "Student",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department_DepartmentId",
                table: "Student",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department_DepartmentId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_DepartmentId",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department_Id",
                table: "Student",
                column: "Id",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
