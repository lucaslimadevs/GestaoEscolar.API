using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GEscolarAPI.Infra.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class create_notificacao_nota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "TBLNOTIFICACAONOTA",
                columns: table => new
                {
                    IDNOTIFICACAONOTA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDDISCIPLINA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOTA = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLNOTIFICACAONOTA", x => x.IDNOTIFICACAONOTA);
                    table.ForeignKey(
                        name: "FK_TBLNOTIFICACAONOTA_AspNetUsers_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLNOTIFICACAONOTA_TBLDISCIPLINA_IDDISCIPLINA",
                        column: x => x.IDDISCIPLINA,
                        principalTable: "TBLDISCIPLINA",
                        principalColumn: "IDDISCIPLINA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBLNOTIFICACAONOTA_IDDISCIPLINA",
                table: "TBLNOTIFICACAONOTA",
                column: "IDDISCIPLINA");

            migrationBuilder.CreateIndex(
                name: "IX_TBLNOTIFICACAONOTA_IDUSUARIO",
                table: "TBLNOTIFICACAONOTA",
                column: "IDUSUARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBLNOTIFICACAONOTA");
        }
    }
}
