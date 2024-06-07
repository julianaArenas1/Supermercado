using Supermercado.DAL.Entities;
using System.Diagnostics.Metrics;

namespace Supermercado.Domain.Interfaces
{
    public interface IProductService
    {
        //Creación de los métodos para productos
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> EditProductAsync(Product product);
        Task<Product> DeleteProductAsync(Guid id);
    }
}
