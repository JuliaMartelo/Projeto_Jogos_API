using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jogos_API.Migrations
{
    /// <inheritdoc />
    public partial class Jogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogo",
                columns: table => new
                {
                    JogoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeDoJogo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Plataforma = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogo", x => x.JogoID);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Nickname = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    JogoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Usuario_Jogo_JogoID",
                        column: x => x.JogoID,
                        principalTable: "Jogo",
                        principalColumn: "JogoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_NomeDoJogo",
                table: "Jogo",
                column: "NomeDoJogo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_JogoID",
                table: "Usuario",
                column: "JogoID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Nickname",
                table: "Usuario",
                column: "Nickname",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Jogo");
        }
    }
}
