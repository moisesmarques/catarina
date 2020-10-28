using Microsoft.EntityFrameworkCore.Migrations;

namespace Catarina.Data.Migrations
{
    public partial class NovasEntidades2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CEP2",
                table: "Estados",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEP2",
                table: "Estados");
        }
    }
}
