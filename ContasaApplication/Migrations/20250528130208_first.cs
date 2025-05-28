using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContasApplication.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Mes_MesReferenciaId",
                table: "Despesas");

            migrationBuilder.RenameColumn(
                name: "MesReferencia",
                table: "Mes",
                newName: "MesReferenciaId");

            migrationBuilder.RenameColumn(
                name: "MesReferenciaId",
                table: "Despesas",
                newName: "MesReferenciaIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Despesas_MesReferenciaId",
                table: "Despesas",
                newName: "IX_Despesas_MesReferenciaIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Mes_MesReferenciaIdId",
                table: "Despesas",
                column: "MesReferenciaIdId",
                principalTable: "Mes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Mes_MesReferenciaIdId",
                table: "Despesas");

            migrationBuilder.RenameColumn(
                name: "MesReferenciaId",
                table: "Mes",
                newName: "MesReferencia");

            migrationBuilder.RenameColumn(
                name: "MesReferenciaIdId",
                table: "Despesas",
                newName: "MesReferenciaId");

            migrationBuilder.RenameIndex(
                name: "IX_Despesas_MesReferenciaIdId",
                table: "Despesas",
                newName: "IX_Despesas_MesReferenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Mes_MesReferenciaId",
                table: "Despesas",
                column: "MesReferenciaId",
                principalTable: "Mes",
                principalColumn: "Id");
        }
    }
}
