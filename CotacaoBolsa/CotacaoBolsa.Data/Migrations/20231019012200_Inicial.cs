using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CotacaoBolsa.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cotacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCotacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    CodigoAtivo = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ValorFechamento = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotacao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotacao_DataCotacao",
                table: "Cotacao",
                column: "DataCotacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cotacao");
        }
    }
}
