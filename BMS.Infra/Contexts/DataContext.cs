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
            modelBuilder.Entity<Venda>().ToTable("Venda");
            modelBuilder.Entity<Venda>().HasKey(x => x.Id);
            modelBuilder.Entity<Venda>().HasOne<Usuario>(u => u.Usuario).WithMany().HasForeignKey(u => u.Id);
            // modelBuilder.Entity<Venda>().HasMany<VendaItem>(b => b.Itens).WithOne();
            // modelBuilder.Entity<Venda>().HasMany<VendaPagamento>(x => x.Pagamentos).WithOne();
            modelBuilder.Entity<Venda>().Property(x => x.DataDaVenda).HasColumnType("datetime");
            modelBuilder.Entity<Venda>().Property(x => x.Desconto).HasColumnType("decimal(18,2");
            modelBuilder.Entity<Venda>().Property(x => x.Status).HasColumnType("int");
            modelBuilder.Entity<Venda>().Property(x => x.Total).HasColumnType("decimal(18,2");

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Usuario>().HasKey(x => x.Id);
            modelBuilder.Entity<Usuario>().Property(x => x.Login);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha);

            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Produto>().HasKey(x => x.Id);
            modelBuilder.Entity<Produto>().Property(x => x.Codigo).HasMaxLength(24);
            modelBuilder.Entity<Produto>().Property(x => x.Nome).HasMaxLength(80);
            modelBuilder.Entity<Produto>().Property(x => x.Descricao);
            modelBuilder.Entity<Produto>().Property(x => x.PrecoCusto).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Produto>().Property(x => x.PrecoVenda).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<VendaItem>().ToTable("VendaProduto");
            modelBuilder.Entity<VendaItem>().HasKey(x => x.Id);
            modelBuilder.Entity<VendaItem>().HasOne<Produto>().WithMany().HasForeignKey(u => u.Id);
            modelBuilder.Entity<VendaItem>().HasOne<Venda>().WithMany().HasForeignKey(u => u.Id);
            modelBuilder.Entity<VendaItem>().Property(x => x.Quantidade);
            modelBuilder.Entity<VendaItem>().Property(x => x.Valor);

            modelBuilder.Entity<VendaPagamento>().ToTable("VendaPagamento");
            modelBuilder.Entity<VendaPagamento>().Property(x => x.Id);
            modelBuilder.Entity<VendaPagamento>().HasOne<Venda>().WithMany().HasForeignKey(v => v.Id);
            modelBuilder.Entity<VendaPagamento>().Property(x => x.Tipo).HasColumnType("int");
            modelBuilder.Entity<VendaPagamento>().Property(x => x.Troco).HasColumnType("decimal(18,2");
            modelBuilder.Entity<VendaPagamento>().Property(x => x.Valor).HasColumnType("decimal(18,2");
            modelBuilder.Entity<VendaPagamento>().Ignore(x => x.Notificacoes);
        }
    }
}
