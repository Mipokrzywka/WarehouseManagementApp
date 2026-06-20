using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ForecastUpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5403));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5249));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5250));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5532));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ForecastUpdatedAt" },
                values: new object[] { new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5471), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ForecastUpdatedAt" },
                values: new object[] { new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5483), null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5329));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5335));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5336));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5608));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5540));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 20, 14, 59, 6, 197, DateTimeKind.Utc).AddTicks(5543));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForecastUpdatedAt",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9306));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9095));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9153));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9035));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9215));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 18, 14, 14, 2, 273, DateTimeKind.Utc).AddTicks(9219));
        }
    }
}
