using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WarehouseManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class InitWarehouseDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OldData",
                table: "ActivityLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Magazyn" },
                    { 2, "Zamówienia" },
                    { 3, "Użytkownicy" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Witaj w systemie WMS! Zmień swoje hasło po pierwszym zalogowaniu.", new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9253), null, null },
                    { 2, "Przypomnienie: W piątek odbędzie się inwentaryzacja sektora A.", new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9258), null, null }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nowe" },
                    { 2, "W realizacji" },
                    { 3, "Wysłane" },
                    { 4, "Anulowane" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9043), null, "Odczyt wszystkich danych", "Read_All", null },
                    { 2, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9046), null, "Zapis i edycja danych", "Write_All", null },
                    { 3, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9048), null, "Usuwanie rekordów z systemu", "Delete_Records", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9004), null, "Elektronika", null },
                    { 2, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9009), null, "Narzędzia", null },
                    { 3, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9011), null, "Chemia magazynowa", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9085), null, "Administrator", null },
                    { 2, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9088), null, "Manager", null },
                    { 3, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9090), null, "Pracownik", null }
                });

            migrationBuilder.InsertData(
                table: "TaskStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Do zrobienia" },
                    { 2, "W toku" },
                    { 3, "Zakończone" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "FirstName", "PasswordHash", "Surname", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9170), null, "admin@wms.pl", "Jan", "AQAAAAEAACcQAAAAEFA...", "Kowalski", null },
                    { 2, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9181), null, "pracownik@wms.pl", "Adam", "AQAAAAEAACcQAAAAEFA...", "Nowak", null }
                });

            migrationBuilder.InsertData(
                table: "ActivityLogs",
                columns: new[] { "Id", "Action", "ComponentId", "CreatedAt", "ModuleId", "NewData", "OldData", "UserId" },
                values: new object[] { 1, "CREATE_PRODUCT", 101, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9683), 1, "{'Name': 'Laptop Dell Vostro', 'Qty': 15}", "", 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CostAmt", "CreatedAt", "CreatorId", "DeletedAt", "ReviewerId", "StatusId", "UpdatedAt", "UserId" },
                values: new object[] { 1, 3950.50m, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9581), 2, null, null, 1, null, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CostAmt", "CreatedAt", "DeletedAt", "ForecastDepletionDate", "Name", "QrCode", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 3500.00m, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9407), null, null, "Laptop Dell Vostro", "QR-LAP-001", 15, null },
                    { 2, 2, 450.50m, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9416), null, null, "Wkrętarka Makita 18V", "QR-TOO-052", 40, null }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserNotifications",
                columns: new[] { "NotificationId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "WorkTasks",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "RoleId", "StatusId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9501), null, "Rozładunek dostawy elektroniki z palety P-10", 3, 1, null },
                    { 2, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9506), null, "Weryfikacja stanów chemii w sektorze C", 2, 2, null }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId", "CostAmt", "CreatedAt", "DeletedAt", "Id", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 3500.00m, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9641), null, 0, 1, null },
                    { 1, 2, 450.50m, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9650), null, 0, 1, null }
                });

            migrationBuilder.InsertData(
                table: "ProductChanges",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "ProductId", "QuantityChanged", "Reason" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9481), 1, 1, 15, "Dostawa zewnętrzna" },
                    { 2, new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9486), 1, 2, 40, "Dostawa zewnętrzna" }
                });

            migrationBuilder.InsertData(
                table: "TaskComments",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedById", "DeletedAt", "TaskId", "UpdatedAt" },
                values: new object[] { 1, "Kurier się spóźnia, rozładunek przesunięty na 14:00", new DateTime(2026, 5, 24, 13, 0, 10, 302, DateTimeKind.Utc).AddTicks(9568), 2, null, 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserNotifications",
                keyColumns: new[] { "NotificationId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserNotifications",
                keyColumns: new[] { "NotificationId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "UserNotifications",
                keyColumns: new[] { "NotificationId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "OldData",
                table: "ActivityLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
