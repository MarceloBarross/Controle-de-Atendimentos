using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleAtendimentos.Migrations
{
    /// <inheritdoc />
    public partial class RestrictDeleteSetorPrioridade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Prioridades_prioridadeid",
                table: "Chamados");

            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Setores_setorid",
                table: "Chamados");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Prioridades_prioridadeid",
                table: "Chamados",
                column: "prioridadeid",
                principalTable: "Prioridades",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Setores_setorid",
                table: "Chamados",
                column: "setorid",
                principalTable: "Setores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Prioridades_prioridadeid",
                table: "Chamados");

            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Setores_setorid",
                table: "Chamados");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Prioridades_prioridadeid",
                table: "Chamados",
                column: "prioridadeid",
                principalTable: "Prioridades",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Setores_setorid",
                table: "Chamados",
                column: "setorid",
                principalTable: "Setores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
