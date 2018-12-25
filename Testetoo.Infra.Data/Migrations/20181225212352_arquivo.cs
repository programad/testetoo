using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Testetoo.Infra.Data.Migrations
{
    public partial class arquivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    IdUsuario = table.Column<Guid>(nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Bytes = table.Column<byte[]>(nullable: true),
                    UsuarioId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arquivos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_UsuarioId",
                table: "Arquivos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivos");
        }
    }
}
