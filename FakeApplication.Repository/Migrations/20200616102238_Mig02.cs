using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeApplication.Repository.Migrations
{
    public partial class Mig02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Anchors",
                columns: new[] { "Id", "X", "Y", "Z" },
                values: new object[,]
                {
                    { 512, 8.5356280000000009, 27.0, 60.120510000000003 },
                    { 513, 8.5356280000000009, 27.0, 7.2367290000000004 },
                    { 514, 34.884740000000001, 27.0, 95.933040000000005 },
                    { 515, 99.458629999999999, 27.0, 89.252989999999997 },
                    { 516, 144.92009999999999, 27.0, 66.058340000000001 },
                    { 517, 160.32140000000001, 27.0, 8.9067430000000005 },
                    { 518, 96.860830000000007, 27.0, 7.7934000000000001 },
                    { 519, 55.852699999999999, 27.0, 8.9067430000000005 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Anchors",
                keyColumn: "Id",
                keyValue: 512);

            migrationBuilder.DeleteData(
                table: "Anchors",
                keyColumn: "Id",
                keyValue: 513);

            migrationBuilder.DeleteData(
                table: "Anchors",
                keyColumn: "Id",
                keyValue: 514);

            migrationBuilder.DeleteData(
                table: "Anchors",
                keyColumn: "Id",
                keyValue: 515);

            migrationBuilder.DeleteData(
                table: "Anchors",
                keyColumn: "Id",
                keyValue: 516);

            migrationBuilder.DeleteData(
                table: "Anchors",
                keyColumn: "Id",
                keyValue: 517);

            migrationBuilder.DeleteData(
                table: "Anchors",
                keyColumn: "Id",
                keyValue: 518);

            migrationBuilder.DeleteData(
                table: "Anchors",
                keyColumn: "Id",
                keyValue: 519);
        }
    }
}
