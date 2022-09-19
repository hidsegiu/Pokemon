using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Web.Migrations
{
    public partial class SeedRolesAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bbb7235a-02e5-47d2-a58c-484782713b7f", "8e72100c-00ce-4f93-806c-2cb329fb1f0f", "Administrator", "ADMINISTRATOR" },
                    { "dbf1dc7j-cf6a-1534-9534-d4177d64c17a", "1a1eed55-1992-4462-8fca-0262c2a98c35", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "daf7dc7a-cf6a-4834-9544-d4177d64b48d", 0, "cd976b74-77b9-4863-99d1-85c2392bc2b8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "USER", "AQAAAAEAACcQAAAAEEDVlVIFv+pVD2dsBj50QGtlTxVz3eAoh6QABqR1+MZiHKn6AdQyU+yS2HmmAflZsA==", null, false, "34c15400-ee44-40a1-b8e0-80385dcbd01a", false, "user" },
                    { "ddd7435a-02e5-41d2-a58c-484782713b7f", 0, "dc5c8cc8-f82a-4de7-bbcf-cb6a86d61b3d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEDCIWDtcwPuBYFDZhdyIoEawYaz0GkXQlu+FgbZg7m84dDyY7+cGqmLT7PaF0fgR7Q==", null, false, "d28ad835-e83c-4fd4-a8c3-bf0dcfe74688", false, "administrator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dbf1dc7j-cf6a-1534-9534-d4177d64c17a", "daf7dc7a-cf6a-4834-9544-d4177d64b48d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bbb7235a-02e5-47d2-a58c-484782713b7f", "ddd7435a-02e5-41d2-a58c-484782713b7f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dbf1dc7j-cf6a-1534-9534-d4177d64c17a", "daf7dc7a-cf6a-4834-9544-d4177d64b48d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bbb7235a-02e5-47d2-a58c-484782713b7f", "ddd7435a-02e5-41d2-a58c-484782713b7f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbb7235a-02e5-47d2-a58c-484782713b7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbf1dc7j-cf6a-1534-9534-d4177d64c17a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "daf7dc7a-cf6a-4834-9544-d4177d64b48d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddd7435a-02e5-41d2-a58c-484782713b7f");
        }
    }
}
