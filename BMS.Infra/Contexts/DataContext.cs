using System;
using BMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BMS.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<VendaPagamento> Pagamentos { get; set; }
        public DbSet<VendaItem> itens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasKey(x => x.Codigo);
            modelBuilder.Entity<Produto>().Property(x => x.Codigo).ValueGeneratedNever();
            modelBuilder.Entity<Produto>().Property(x => x.Codigo).IsRequired();

            modelBuilder.Entity<VendaPagamento>().Ignore(x => x.Notificacoes);
            modelBuilder.Entity<VendaItem>().Ignore(x => x.Produto);

            modelBuilder.Entity<Venda>().Ignore(x => x.Usuario);

        }
    }
}
