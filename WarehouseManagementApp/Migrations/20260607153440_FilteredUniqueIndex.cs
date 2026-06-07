using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class FilteredUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Name_CategoryId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7519));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7582));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7583));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7941));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7647));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 7, 15, 34, 39, 522, DateTimeKind.Utc).AddTicks(7901));

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name_CategoryId",
                table: "Products",
                columns: new[] { "Name", "CategoryId" },
                unique: true,
                filter: "[DeletedAt] IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Name_CategoryId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9683));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9253));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9581));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9046));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9085));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9088));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9506));

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name_CategoryId",
                table: "Products",
                columns: new[] { "Name", "CategoryId" },
                unique: true);
        }
    }
}
