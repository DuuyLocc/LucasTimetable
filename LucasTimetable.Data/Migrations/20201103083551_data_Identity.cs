using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LucasTimetable.Data.Migrations
{
    public partial class data_Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppRoles",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9"),
                column: "ConcurrencyStamp",
                value: "eeb6efd3-04fb-4c81-bd7f-4675ed98d819");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("ddcfd40f-0c20-4bbd-afbf-5936032ddde5"),
                column: "ConcurrencyStamp",
                value: "8a93e752-eb34-49e8-957c-cdcac405a9b0");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ac193196-9739-4c7b-bac0-390812e074a5", "AQAAAAEAACcQAAAAEInFkfq/TNaYKXthuQ7paCYWMNEPh2tEA+fqAZmCEWNO2YjPzMmuKvXGlpDlwjJkyQ==" });

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Priority", "Status" },
                values: new object[] { "Make a plan", 1, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e2de1ee-b97b-4698-abe4-c22a0332b2c9"),
                column: "ConcurrencyStamp",
                value: "4dea93c3-09f5-4ce4-a0b1-3726a6dce9e8");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("ddcfd40f-0c20-4bbd-afbf-5936032ddde5"),
                column: "ConcurrencyStamp",
                value: "d3941713-0920-4a79-825e-b359a1b65b27");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8dd4e4e7-cbb1-4db8-8cd8-3024401afc74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "95f6d13b-cb4c-450a-b5c7-600df3613d35", "AQAAAAEAACcQAAAAEFjGcvLB1IAkKvrYqC/saSuKdSLijM4XiTIpi6h3h+zXx0pmjHMYWnldDT/RKvFCTA==" });

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Priority", "Status" },
                values: new object[] { "make a plan", 1, 0 });
        }
    }
}
