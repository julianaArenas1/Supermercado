using Microsoft.EntityFrameworkCore;
using Supermercado.DAL;
using Supermercado.DAL.Entities;
using Supermercado.Domain.Interfaces;

namespace Supermercado.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly DataBaseContext _context;

        public ProductService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }
        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

      
        public async Task<Product> CreateProductAsync(Product product)
        {
            product.Id = Guid.NewGuid();
            product.CreatedDate = DateTime.Now;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProductAsync(Guid id)
        {
            var product = await GetProductByIdAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return product;
            }
            return null;
        }

        public async Task<Product> EditProductAsync(Product product)
        {
            product.ModifiedDate = DateTime.Now;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

       
    }
}
