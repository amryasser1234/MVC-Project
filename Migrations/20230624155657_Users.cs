using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectOwn.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08503213-9226-4c0c-a12e-29904e7c1c93", "de2666d5-9cf4-4331-b94b-788d17aee4f3", "User", "user" },
                    { "b8668972-434d-4345-b550-90e80a0208c6", "1180ac0b-705d-42cf-9429-8fee8fa23571", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08503213-9226-4c0c-a12e-29904e7c1c93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8668972-434d-4345-b550-90e80a0208c6");
        }
    }
}
