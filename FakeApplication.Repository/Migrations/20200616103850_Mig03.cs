using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeApplication.Repository.Migrations
{
    public partial class Mig03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "IsActive", "SignalFrequency", "X", "Y", "Z" },
                values: new object[] { 42, false, 0, 53.0, 199.0, 82.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 42);
        }
    }
}
