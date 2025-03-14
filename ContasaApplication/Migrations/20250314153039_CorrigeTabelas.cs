using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContasApplication.Migrations
{
    /// <inheritdoc />
    public partial class CorrigeTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtiquetaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MesReferencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valorTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDespesa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorDespesa = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Parcelado = table.Column<bool>(type: "bit", nullable: false),
                    QuantidadeParcelas = table.Column<int>(type: "int", nullable: false),
                    QuantidadeParcelasPagas = table.Column<int>(type: "int", nullable: false),
                    MesFimParcelado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DespesaFixa = table.Column<bool>(type: "bit", nullable: false),
                    IdParcelado = table.Column<int>(type: "int", nullable: false),
                    MesReferenciaId = table.Column<int>(type: "int", nullable: true),
                    Etiqueta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesas_Mes_MesReferenciaId",
                        column: x => x.MesReferenciaId,
                        principalTable: "Mes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_MesReferenciaId",
                table: "Despesas",
                column: "MesReferenciaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropTable(
                name: "Mes");
        }
    }
}
