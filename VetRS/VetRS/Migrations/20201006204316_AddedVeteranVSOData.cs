using Microsoft.EntityFrameworkCore.Migrations;

namespace VetRS.Migrations
{
    public partial class AddedVeteranVSOData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be80f185-eae4-4bae-a02c-88ef7b6f459a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66f9178a-3e8d-4b01-8b62-abb101386ed2", "4591d093-fca3-4b34-9527-eea626306d7f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "VSO",
                columns: new[] { "Id", "Email", "FirstName", "IdentityUserId", "ImageLocation", "LastName", "PhoneNumber", "VSOCity", "VSOState", "VSOStreet", "VSOZipCode" },
                values: new object[,]
                {
                    { 1, "Lombardibarbie@PackersChamps.com", "Aaron", null, "", "Rodgers", "9205552020", "Milwaukee", "WI", "Martin Luther King Ave.", 53022 },
                    { 2, "Gunslinger@PackersChamps.com", "Brett", null, "", "Farve", "9203332020", "Milwaukee", "WI", "6th St.", 53022 },
                    { 3, "MrHands@PackersChamps.com", "Jordy", null, "", "Nelson", "5558675309", "Milwaukee", "WI", "31st St.", 53022 },
                    { 4, "Doubleyourdoublecheck@PackersChamps.com", "BJ", null, "", "Raji", "5552344545", "Milwaukee", "Wisconsin", "22nd St.", 53022 },
                    { 5, "Astarrisborn@packerschamps.com", "Bart", null, "", "Starr", "5558761515", "Milwaukee", "WI", "17th St.", 53022 }
                });

            migrationBuilder.InsertData(
                table: "Veteran",
                columns: new[] { "Id", "Email", "FirstName", "IdentityUserId", "ImageLocation", "LastName", "PhoneNumber", "VeteranCity", "VeteranState", "VeteranStreet", "VeteranZipCode" },
                values: new object[,]
                {
                    { 1, "Sgtjosetorres@yahoo.com", "Jose", null, "", "Torres", "9203827037", "Beaver Dam", "WI", "515 Walnut St", 53916 },
                    { 2, "Thatdude@softwaredeveloper.com", "Eric", null, "", "Hill", "5552452010", "Milwaukee", "WI", "Kilbourn Ave", 53022 },
                    { 3, "Realamericanhero@DevDogg.com", "Chesty", null, "", "Puller", "1234567891", "Milwaukee", "WI", "W. Wisconsin Ave.", 53022 },
                    { 4, "MedalOfHonor@armyman.com", "Lucian", null, "", "Adams", "9201119999", "Milwaukee", "WI", "E. State St.", 53022 },
                    { 5, "RealFlyBoy@airforcehero.com", "Steven", null, "", "Bennet", "9998883333", "Milwaukee", "WI", "E. Knapp St.", 53022 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66f9178a-3e8d-4b01-8b62-abb101386ed2");

            migrationBuilder.DeleteData(
                table: "VSO",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VSO",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VSO",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VSO",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VSO",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Veteran",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Veteran",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Veteran",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Veteran",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Veteran",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be80f185-eae4-4bae-a02c-88ef7b6f459a", "9e3b5583-3ecb-48d0-bd88-f38a45f014f6", "Admin", "ADMIN" });
        }
    }
}
