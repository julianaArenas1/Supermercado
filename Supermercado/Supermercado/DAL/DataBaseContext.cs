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
            modelBuilder.Entity<Category>().HasIndex("Name", "CategoryId").IsUnique(); // Haciendo un índice compuesto
            modelBuilder.Entity<Product>().HasIndex("Name", "ProductId").IsUnique();
            modelBuilder.Entity<Sale>().HasIndex("Name", "SupermarketID").IsUnique();
        }

        #region DbSets

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        #endregion
    }
}
