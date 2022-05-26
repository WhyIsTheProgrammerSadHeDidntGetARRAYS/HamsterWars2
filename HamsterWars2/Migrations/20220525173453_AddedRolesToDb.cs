using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamsterWars2.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e14ca20-e0a0-446a-995a-f8bbbc027509", "71963cf3-b2e3-4915-a0fc-81244a3315fa", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb5b5b9b-8288-4d3d-908d-dde4b326cfbc", "12ffab7d-3c21-4aa7-a6c7-1b02e5123e85", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e14ca20-e0a0-446a-995a-f8bbbc027509");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb5b5b9b-8288-4d3d-908d-dde4b326cfbc");
        }
    }
}
