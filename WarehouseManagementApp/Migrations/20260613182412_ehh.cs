using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WarehouseManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class ehh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts");

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(616));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(74));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(79));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(38));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(42));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(44));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(493));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(497));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(423));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(121));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(575));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(202));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(210));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(510));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 18, 24, 11, 310, DateTimeKind.Utc).AddTicks(515));

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId_ProductId",
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_OrderId_ProductId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3884));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CostAmt", "CreatedAt", "CreatorId", "DeletedAt", "ReviewerId", "StatusId", "UpdatedAt", "UserId" },
                values: new object[] { 1, 3950.50m, new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(4132), 2, null, null, 1, null, null });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3715));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3688));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(4001));

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3946));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(3822));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(4017));

            migrationBuilder.UpdateData(
                table: "WorkTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(4021));

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId", "CostAmt", "CreatedAt", "DeletedAt", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 3500.00m, new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(4186), null, 1, null },
                    { 1, 2, 450.50m, new DateTime(2026, 6, 13, 15, 53, 24, 471, DateTimeKind.Utc).AddTicks(4190), null, 1, null }
                });
        }
    }
}
