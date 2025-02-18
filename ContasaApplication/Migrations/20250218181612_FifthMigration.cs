using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContasApplication.Migrations
{
    /// <inheritdoc />
    public partial class FifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MesReferenciaId",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MesReferencia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_MesReferenciaId",
                table: "Despesas",
                column: "MesReferenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Mes_MesReferenciaId",
                table: "Despesas",
                column: "MesReferenciaId",
                principalTable: "Mes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Mes_MesReferenciaId",
                table: "Despesas");

            migrationBuilder.DropTable(
                name: "Mes");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_MesReferenciaId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "MesReferenciaId",
                table: "Despesas");
        }
    }
}
