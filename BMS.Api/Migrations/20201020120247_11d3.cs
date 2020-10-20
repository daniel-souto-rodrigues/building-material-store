using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMS.Api.Migrations
{
    public partial class _11d3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Usuarios_Id",
                table: "Vendas");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Vendas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UsuarioId",
                table: "Vendas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Usuarios_UsuarioId",
                table: "Vendas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Usuarios_UsuarioId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_UsuarioId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Vendas");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Usuarios_Id",
                table: "Vendas",
                column: "Id",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
