using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class UserModuleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5418));

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Users" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5164));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5018));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5026));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5027));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5245));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5383));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5317));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(869));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(870));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(710));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(714));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(986));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(936));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(942));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(809));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(811));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(1055));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(837));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(843));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(1000));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 14, 15, 8, 8, 237, DateTimeKind.Utc).AddTicks(1004));
        }
    }
}
