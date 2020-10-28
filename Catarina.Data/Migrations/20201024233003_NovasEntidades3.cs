using Microsoft.EntityFrameworkCore.Migrations;

namespace Catarina.Data.Migrations
{
    public partial class NovasEntidades3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TipoLogradouros",
                keyColumn: "Id",
                keyValue: 6,
                column: "Descricao",
                value: "Condomínio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TipoLogradouros",
                keyColumn: "Id",
                keyValue: 6,
                column: "Descricao",
                value: "Condominio");
        }
    }
}
