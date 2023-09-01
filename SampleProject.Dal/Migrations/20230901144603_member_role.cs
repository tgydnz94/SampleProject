using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleProject.Dal.Migrations
{
    public partial class member_role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56f0c193-950f-4d3c-b8c7-505a2e66f7b2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be5ca545-c29c-4273-967e-e721238b238b", "83ca811a-d9ee-474f-8955-3702f21b267a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "474ffbd4-d4c6-4a24-97ab-a93c24ea9eea", "f88304c8-8c18-4657-a477-b5fa3e8916e8", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "474ffbd4-d4c6-4a24-97ab-a93c24ea9eea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be5ca545-c29c-4273-967e-e721238b238b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56f0c193-950f-4d3c-b8c7-505a2e66f7b2", "84d6b933-a6c9-4aa3-9622-f2b9e677411d", "Admin", "ADMIN" });
        }
    }
}
