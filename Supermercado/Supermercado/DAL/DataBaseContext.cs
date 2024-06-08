using Microsoft.EntityFrameworkCore;
using Supermercado.DAL.Entities;

namespace Supermercado.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        //Este método que es propio de EF CORE me sirve para configurar unos índices de cada campo de una tabla en BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductSale>()
                .HasKey(ps => new { ps.productId, ps.saleId });

            modelBuilder.Entity<ProductSale>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSales)
                .HasForeignKey(ps => ps.productId);

            modelBuilder.Entity<ProductSale>()
                .HasOne(ps => ps.Sale)
                .WithMany(s => s.ProductSales)
                .HasForeignKey(ps => ps.saleId);

            modelBuilder.Entity<Sale>().HasIndex(s => s.Id).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(p => p.Id).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Id).IsUnique();
        }

        #region DbSets

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ProductSale> ProductSales { get; set; }

        #endregion
    }
}
