using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WarehouseManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class PermissionsFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Access to all application functionalities and data", "Access:All" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Access to view all products", "Products:Read" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Access to add, update and delete products", "Products:Manage" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 4, "Access to view all product categories", "ProductCategories:Read" },
                    { 5, "Access to add, update and delete product categories", "ProductCategories:Manage" },
                    { 6, "Access to view all orders", "Orders:Read" },
                    { 7, "Access to add new order requests", "Orders:Create" },
                    { 8, "Access to process orders", "Orders:Process" },
                    { 9, "Access to view all users", "Users:Read" },
                    { 10, "Access to add, update and delete users", "Users:Manage" },
                    { 11, "Access to view all roles", "Roles:Read" },
                    { 12, "Access to add, update and delete Roles", "Roles:Manage" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 13, 43, 43, 931, DateTimeKind.Utc).AddTicks(5418));

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
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Odczyt wszystkich danych", "Read_All" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Zapis i edycja danych", "Write_All" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Usuwanie rekordów z systemu", "Delete_Records" });

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
    }
}
