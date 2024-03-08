using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShooterLink.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    NickName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    Verified = table.Column<bool>(type: "boolean", nullable: false),
                    Token = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Created = table.Column<DateTime>(type: "Timestamp", nullable: false, defaultValue: new DateTime(2024, 3, 8, 18, 39, 27, 344, DateTimeKind.Local).AddTicks(8741))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SettingName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    StringValue = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    BoolValue = table.Column<bool>(type: "boolean", nullable: true),
                    DateValue = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IntValue = table.Column<int>(type: "integer", nullable: true),
                    DoubleValue = table.Column<double>(type: "double precision", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifierId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "Timestamp", nullable: false, defaultValue: new DateTime(2024, 3, 8, 18, 39, 27, 344, DateTimeKind.Local).AddTicks(7301)),
                    Modified = table.Column<DateTime>(type: "Timestamp", nullable: false, defaultValue: new DateTime(2024, 3, 8, 18, 39, 27, 344, DateTimeKind.Local).AddTicks(7794))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Settings_Users_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1ca61828-4c2b-4af5-b551-498f97b864b7"), "Admin" },
                    { new Guid("6239f1d1-6dae-40c0-bf45-9ff9fd75216f"), "Athlete" },
                    { new Guid("b1106934-acd5-4000-a4e3-0b789d28f494"), "Coach" },
                    { new Guid("d7309100-d517-403c-8584-b005a406847d"), "Office" },
                    { new Guid("e5e88f2c-953c-4fe2-862e-0e5ff74242fd"), "Guest" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_CreatorId",
                table: "Settings",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_ModifierId",
                table: "Settings",
                column: "ModifierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
