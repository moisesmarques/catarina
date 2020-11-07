using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catarina.Data.Migrations
{
    public partial class NovasEntidades4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imovel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    ValorAluguel = table.Column<decimal>(nullable: false),
                    ProprietarioId = table.Column<long>(nullable: true),
                    LocadorId = table.Column<long>(nullable: true),
                    LogradouroId = table.Column<int>(nullable: true),
                    Dormitorios = table.Column<int>(nullable: false),
                    Camas = table.Column<int>(nullable: false),
                    LavadouraRoupa = table.Column<bool>(nullable: false),
                    SecadouraRoupa = table.Column<bool>(nullable: false),
                    LavadouraLouca = table.Column<bool>(nullable: false),
                    Geladeira = table.Column<bool>(nullable: false),
                    Televisao = table.Column<bool>(nullable: false),
                    Fogao = table.Column<bool>(nullable: false),
                    Forno = table.Column<bool>(nullable: false),
                    Microondas = table.Column<bool>(nullable: false),
                    Elevador = table.Column<bool>(nullable: false),
                    AceitaCrianca = table.Column<bool>(nullable: false),
                    AceitaAnimal = table.Column<bool>(nullable: false),
                    Garagens = table.Column<int>(nullable: false),
                    Lotacao = table.Column<int>(nullable: false),
                    Piso = table.Column<int>(nullable: false),
                    AguaIncluida = table.Column<bool>(nullable: false),
                    EletricidadeIncluida = table.Column<bool>(nullable: false),
                    MediaAgua = table.Column<decimal>(nullable: false),
                    MediaEletricidade = table.Column<decimal>(nullable: false),
                    DisponivelEm = table.Column<DateTime>(nullable: false),
                    Academia = table.Column<bool>(nullable: false),
                    PiscinaCondominio = table.Column<bool>(nullable: false),
                    Piscina = table.Column<bool>(nullable: false),
                    Playground = table.Column<bool>(nullable: false),
                    QuadraEsportiva = table.Column<bool>(nullable: false),
                    Sauna = table.Column<bool>(nullable: false),
                    SalaoFesta = table.Column<bool>(nullable: false),
                    SalaConferencia = table.Column<bool>(nullable: false),
                    ChurrasqueiraCondominio = table.Column<bool>(nullable: false),
                    Churrasqueira = table.Column<bool>(nullable: false),
                    Sacada = table.Column<bool>(nullable: false),
                    Cobertura = table.Column<bool>(nullable: false),
                    Portaria24 = table.Column<bool>(nullable: false),
                    AlarmeIncendio = table.Column<bool>(nullable: false),
                    SensorFumaca = table.Column<bool>(nullable: false),
                    ChuveiroGas = table.Column<bool>(nullable: false),
                    TorneirasAquecidas = table.Column<bool>(nullable: false),
                    Internet = table.Column<bool>(nullable: false),
                    Wifi = table.Column<bool>(nullable: false),
                    Metros = table.Column<int>(nullable: false),
                    Banheiros = table.Column<int>(nullable: false),
                    EspacoGourmet = table.Column<bool>(nullable: false),
                    BanheiraHidromassagem = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imovel_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Imovel_Pessoas_LocadorId",
                        column: x => x.LocadorId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Imovel_Logradouros_LogradouroId",
                        column: x => x.LogradouroId,
                        principalTable: "Logradouros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Imovel_Pessoas_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Imovel_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImovelImagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Tamanho = table.Column<int>(nullable: false),
                    Largura = table.Column<int>(nullable: false),
                    Altura = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    DescricaoLonga = table.Column<string>(nullable: true),
                    Conteudo = table.Column<string>(nullable: true),
                    ImovelId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImovelImagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImovelImagem_Imovel_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imovel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_CreatedById",
                table: "Imovel",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_LocadorId",
                table: "Imovel",
                column: "LocadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_LogradouroId",
                table: "Imovel",
                column: "LogradouroId");

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_ProprietarioId",
                table: "Imovel",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_UpdatedById",
                table: "Imovel",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ImovelImagem_ImovelId",
                table: "ImovelImagem",
                column: "ImovelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImovelImagem");

            migrationBuilder.DropTable(
                name: "Imovel");
        }
    }
}
