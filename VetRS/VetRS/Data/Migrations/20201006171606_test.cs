using Microsoft.EntityFrameworkCore.Migrations;

namespace VetRS.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30087c49-e717-4235-a8a1-439988c5872c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b1ee7fa-7224-4eff-a602-5ed12fd62cfe", "e911f8ae-7082-4d39-95e7-47b10632f41f", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b1ee7fa-7224-4eff-a602-5ed12fd62cfe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30087c49-e717-4235-a8a1-439988c5872c", "89054819-bdc3-47d3-ae1a-56ae295050a1", "Admin", "ADMIN" });
        }
    }
}
