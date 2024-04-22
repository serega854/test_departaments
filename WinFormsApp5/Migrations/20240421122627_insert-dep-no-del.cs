using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinFormsApp5.Migrations
{
    /// <inheritdoc />
    public partial class insertdepnodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_ParentDepartmentId",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId1",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentId1", "Name", "ParentDepartmentId" },
                values: new object[] { 1, null, "Заводоуправление", null });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentId1",
                table: "Departments",
                column: "DepartmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_DepartmentId1",
                table: "Departments",
                column: "DepartmentId1",
                principalTable: "Departments",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_ParentDepartmentId",
                table: "Departments",
                column: "ParentDepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_DepartmentId1",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_ParentDepartmentId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentId1",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "Departments");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_ParentDepartmentId",
                table: "Departments",
                column: "ParentDepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }
    }
}
