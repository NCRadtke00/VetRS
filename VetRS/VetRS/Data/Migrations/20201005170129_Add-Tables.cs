using Microsoft.EntityFrameworkCore.Migrations;

namespace VetRS.Data.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "197c0cc1-6541-4bcc-ac9c-93f5f8abb7db");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30087c49-e717-4235-a8a1-439988c5872c", "89054819-bdc3-47d3-ae1a-56ae295050a1", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30087c49-e717-4235-a8a1-439988c5872c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "197c0cc1-6541-4bcc-ac9c-93f5f8abb7db", "0b9e23d4-84d2-42ed-abb2-6875e9ea96ac", "Admin", "ADMIN" });
        }
    }
}
