using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Zakazakum.EntityFramework.Migrations
{
    public partial class OrderID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserOrders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "UserOrders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsOrderPaid",
                table: "UserOrders",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserOrders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Restaurants",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Restaurants",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "DeliveryCost",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserOrderId",
                table: "FoodOrder",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FoodId",
                table: "FoodOrder",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "FoodOrder",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "FoodOrder",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "FoodOrder",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Food",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "Food",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Food",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Cost",
                table: "Food",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Food",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserOrders",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "UserOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsOrderPaid",
                table: "UserOrders",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserOrders",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Restaurants",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Restaurants",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "Orders",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Orders",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "DeliveryCost",
                table: "Orders",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UserOrderId",
                table: "FoodOrder",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FoodId",
                table: "FoodOrder",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "FoodOrder",
                type: "int",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "FoodOrder",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "FoodOrder",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Food",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "Food",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Food",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Cost",
                table: "Food",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Food",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid));
        }
    }
}
