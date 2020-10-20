using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMS.Api.Migrations
{
    public partial class _1333 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    PrecoCusto = table.Column<decimal>(nullable: false),
                    PrecoVenda = table.Column<decimal>(nullable: false),
                    Deletado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Deletado = table.Column<bool>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Deletado = table.Column<bool>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Desconto = table.Column<decimal>(nullable: false),
                    DataDaVenda = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Usuarios_Id",
                        column: x => x.Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Deletado = table.Column<bool>(nullable: false),
                    Quantidade = table.Column<decimal>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    ProdutoCodigo = table.Column<string>(nullable: true),
                    VendaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_itens_Produtos_ProdutoCodigo",
                        column: x => x.ProdutoCodigo,
                        principalTable: "Produtos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_itens_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Deletado = table.Column<bool>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Troco = table.Column<decimal>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    VendaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_itens_ProdutoCodigo",
                table: "itens",
                column: "ProdutoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_itens_VendaId",
                table: "itens",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_VendaId",
                table: "Pagamentos",
                column: "VendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itens");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
