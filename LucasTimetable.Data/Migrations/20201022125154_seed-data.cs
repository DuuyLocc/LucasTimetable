using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LucasTimetable.Data.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "HomeTile", "This is home page of LucasTimetable" },
                    { "HomeKeyword", "This is keyword of LucasTimetable" },
                    { "HomeDescription", "This is description of LucasTimetable" }
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9"), "4dea93c3-09f5-4ce4-a0b1-3726a6dce9e8", "Quản trị viên", "admin", "admin" },
                    { new Guid("ddcfd40f-0c20-4bbd-afbf-5936032ddde5"), "d3941713-0920-4a79-825e-b359a1b65b27", "Người dùng", "user", "user" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"), new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Ho", "HoTen", "LockoutEnabled", "LockoutEnd", "NgaySinh", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Ten", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"), 0, "95f6d13b-cb4c-450a-b5c7-600df3613d35", "letruongduyloc@gmail.com", true, "Le", "Le Loc", false, null, new DateTime(1998, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "letruongduyloc@gmail.com", "admin", "AQAAAAEAACcQAAAAEFjGcvLB1IAkKvrYqC/saSuKdSLijM4XiTIpi6h3h+zXx0pmjHMYWnldDT/RKvFCTA==", null, false, "", "Loc", false, "admin" });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "Id", "Deadline", "Description", "Name", "Priority", "Status" },
                values: new object[] { 1, new DateTime(2020, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "make a plan", "Note timetable", 1, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeDescription");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeKeyword");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeTile");

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("ddcfd40f-0c20-4bbd-afbf-5936032ddde5"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"), new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"));

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
