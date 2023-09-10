using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleProject.Dal.Migrations
{
    public partial class messageNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "474ffbd4-d4c6-4a24-97ab-a93c24ea9eea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be5ca545-c29c-4273-967e-e721238b238b");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Statu = table.Column<int>(nullable: false),
                    SenderID = table.Column<int>(nullable: false),
                    ReceiverID = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    MessageDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Messages_AppUsers_ReceiverID",
                        column: x => x.ReceiverID,
                        principalTable: "AppUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AppUsers_SenderID",
                        column: x => x.SenderID,
                        principalTable: "AppUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Statu = table.Column<int>(nullable: false),
                    NotificationType = table.Column<string>(nullable: true),
                    NotificationTypeSymbol = table.Column<string>(nullable: true),
                    NotificationDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64971e2e-2472-43c1-ae0b-56b6e709bc2e", "44d19ba6-7078-4c19-8918-001740854bd1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ba14965-000e-49c8-87c0-7e10cdcb1a6c", "3f6a11ba-d6bd-415b-a5c0-e122f350e9e0", "Member", "MEMBER" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverID",
                table: "Messages",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderID",
                table: "Messages",
                column: "SenderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64971e2e-2472-43c1-ae0b-56b6e709bc2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ba14965-000e-49c8-87c0-7e10cdcb1a6c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be5ca545-c29c-4273-967e-e721238b238b", "83ca811a-d9ee-474f-8955-3702f21b267a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "474ffbd4-d4c6-4a24-97ab-a93c24ea9eea", "f88304c8-8c18-4657-a477-b5fa3e8916e8", "Member", "MEMBER" });
        }
    }
}
