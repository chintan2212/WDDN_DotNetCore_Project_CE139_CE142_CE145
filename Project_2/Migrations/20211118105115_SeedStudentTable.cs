using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_2.Migrations
{
    public partial class SeedStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "Id", "department", "email", "gender", "name", "sem" },
                values: new object[] { 3, 0, "chintan@gmail.com", "Male", "Chintan", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
