using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GEscolarAPI.Infra.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial_create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBLDISCIPLINA",
                columns: table => new
                {
                    IDDISCIPLINA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CARGAHORARIA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLDISCIPLINA", x => x.IDDISCIPLINA);
                });

            migrationBuilder.CreateTable(
                name: "TBLBOLETIM",
                columns: table => new
                {
                    IDBOLETIM = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATAENTREGA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLBOLETIM", x => x.IDBOLETIM);
                    table.ForeignKey(
                        name: "FK_TBLBOLETIM_Usuario_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLTURMA",
                columns: table => new
                {
                    IDTURMA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDDISCIPLINA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLTURMA", x => x.IDTURMA);
                    table.ForeignKey(
                        name: "FK_TBLTURMA_TBLDISCIPLINA_IDDISCIPLINA",
                        column: x => x.IDDISCIPLINA,
                        principalTable: "TBLDISCIPLINA",
                        principalColumn: "IDDISCIPLINA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLTURMA_Usuario_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLNOTASBOLETIM",
                columns: table => new
                {
                    IDNOTASBOLETIM = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDTURMA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDBOLETIM = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOTA = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLNOTASBOLETIM", x => x.IDNOTASBOLETIM);
                    table.ForeignKey(
                        name: "FK_TBLNOTASBOLETIM_TBLBOLETIM_IDBOLETIM",
                        column: x => x.IDBOLETIM,
                        principalTable: "TBLBOLETIM",
                        principalColumn: "IDBOLETIM",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLNOTASBOLETIM_TBLTURMA_IDTURMA",
                        column: x => x.IDTURMA,
                        principalTable: "TBLTURMA",
                        principalColumn: "IDTURMA");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBLBOLETIM_IDUSUARIO",
                table: "TBLBOLETIM",
                column: "IDUSUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_TBLNOTASBOLETIM_IDBOLETIM",
                table: "TBLNOTASBOLETIM",
                column: "IDBOLETIM");

            migrationBuilder.CreateIndex(
                name: "IX_TBLNOTASBOLETIM_IDTURMA",
                table: "TBLNOTASBOLETIM",
                column: "IDTURMA");

            migrationBuilder.CreateIndex(
                name: "IX_TBLTURMA_IDDISCIPLINA",
                table: "TBLTURMA",
                column: "IDDISCIPLINA");

            migrationBuilder.CreateIndex(
                name: "IX_TBLTURMA_IDUSUARIO",
                table: "TBLTURMA",
                column: "IDUSUARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBLNOTASBOLETIM");

            migrationBuilder.DropTable(
                name: "TBLBOLETIM");

            migrationBuilder.DropTable(
                name: "TBLTURMA");

            migrationBuilder.DropTable(
                name: "TBLDISCIPLINA");
        }
    }
}
