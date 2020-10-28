using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catarina.Data.Migrations
{
    public partial class NovasEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    DiaNascimento = table.Column<int>(nullable: false),
                    MesNascimento = table.Column<int>(nullable: false),
                    AnoNascimento = table.Column<int>(nullable: false),
                    CPF = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pessoas_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoLogradouros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLogradouros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logradouros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    TipoId = table.Column<int>(nullable: true),
                    EstadoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logradouros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logradouros_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Logradouros_TipoLogradouros_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoLogradouros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<string>(nullable: true),
                    PessoaId = table.Column<long>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    LogradouroId = table.Column<int>(nullable: true),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contatos_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contatos_Logradouros_LogradouroId",
                        column: x => x.LogradouroId,
                        principalTable: "Logradouros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contatos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contatos_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TipoLogradouros",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Acesso" },
                    { 23, "Via" },
                    { 22, "Trevo" },
                    { 21, "Travessa" },
                    { 20, "Servidão" },
                    { 19, "Rua" },
                    { 18, "Rodovia" },
                    { 17, "Recanto" },
                    { 16, "Praia" },
                    { 15, "Praça" },
                    { 14, "Passeio" },
                    { 24, "Via Expressa" },
                    { 13, "Passagem" },
                    { 11, "Loteamento" },
                    { 10, "Largo" },
                    { 9, "Jardim" },
                    { 8, "Estrada" },
                    { 7, "Conjunto" },
                    { 6, "Condominio" },
                    { 5, "Bosque" },
                    { 4, "Beco" },
                    { 3, "Avenida" },
                    { 2, "Alameda" },
                    { 12, "Parque" },
                    { 25, "Vila" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_CreatedById",
                table: "Contatos",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_LogradouroId",
                table: "Contatos",
                column: "LogradouroId");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_PessoaId",
                table: "Contatos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_UpdatedById",
                table: "Contatos",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Logradouros_EstadoId",
                table: "Logradouros",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Logradouros_TipoId",
                table: "Logradouros",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CreatedById",
                table: "Pessoas",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_UpdatedById",
                table: "Pessoas",
                column: "UpdatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Logradouros");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "TipoLogradouros");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CreatedById",
                table: "Persons",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UpdatedById",
                table: "Persons",
                column: "UpdatedById");
        }
    }
}
