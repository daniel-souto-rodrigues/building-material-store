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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // implentar depois
        }
    }
}
