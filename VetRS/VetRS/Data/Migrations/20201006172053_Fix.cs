using Microsoft.EntityFrameworkCore.Migrations;

namespace VetRS.Data.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b1ee7fa-7224-4eff-a602-5ed12fd62cfe");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DOB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ImageLocation = table.Column<string>(nullable: true),
                    DOBId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Education_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Education_DOB_DOBId",
                        column: x => x.DOBId,
                        principalTable: "DOB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Education_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Veteran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ImageLocation = table.Column<string>(nullable: true),
                    DOBId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veteran", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veteran_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Veteran_DOB_DOBId",
                        column: x => x.DOBId,
                        principalTable: "DOB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Veteran_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ImageLocation = table.Column<string>(nullable: true),
                    DOBId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VSO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VSO_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VSO_DOB_DOBId",
                        column: x => x.DOBId,
                        principalTable: "DOB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VSO_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e13cdecb-3ec2-40e7-841c-7a7f65406e93", "7861349c-0fa0-4144-9b1a-a3d49ba2840d", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Education_AddressId",
                table: "Education",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_DOBId",
                table: "Education",
                column: "DOBId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_IdentityUserId",
                table: "Education",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Veteran_AddressId",
                table: "Veteran",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Veteran_DOBId",
                table: "Veteran",
                column: "DOBId");

            migrationBuilder.CreateIndex(
                name: "IX_Veteran_IdentityUserId",
                table: "Veteran",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VSO_AddressId",
                table: "VSO",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_VSO_DOBId",
                table: "VSO",
                column: "DOBId");

            migrationBuilder.CreateIndex(
                name: "IX_VSO_IdentityUserId",
                table: "VSO",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Veteran");

            migrationBuilder.DropTable(
                name: "VSO");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "DOB");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e13cdecb-3ec2-40e7-841c-7a7f65406e93");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b1ee7fa-7224-4eff-a602-5ed12fd62cfe", "e911f8ae-7082-4d39-95e7-47b10632f41f", "Admin", "ADMIN" });
        }
    }
}
