using Microsoft.EntityFrameworkCore.Migrations;

namespace Zakazakum.EntityFramework.Migrations
{
    public partial class BankName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Users");
        }
    }
}
