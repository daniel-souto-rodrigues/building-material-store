using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMS.Api.Migrations
{
    public partial class _111444 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itens_Produtos_ProdutoCodigo",
                table: "itens");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Usuarios_UsuarioId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_UsuarioId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_itens_ProdutoCodigo",
                table: "itens");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Vendas",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProdutoCodigo",
                table: "itens",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Vendas",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "ProdutoCodigo",
                table: "itens",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_UsuarioId",
                table: "Vendas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_itens_ProdutoCodigo",
                table: "itens",
                column: "ProdutoCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_itens_Produtos_ProdutoCodigo",
                table: "itens",
                column: "ProdutoCodigo",
                principalTable: "Produtos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Usuarios_UsuarioId",
                table: "Vendas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
