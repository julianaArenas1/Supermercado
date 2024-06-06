using System;

namespace Supermercado.Domain.Interfaces
{
    public interface ICountryService
    {
        //Creación de métodos para productos
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> EditProductAsync(Product product);
        Task<Product> DeleteProductAsync(Guid id);

        //Creación de métodos para Categorías
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> EditProductAsync(Product product);
        Task<Product> DeleteProductAsync(Guid id);

        //Creación de métodos para Ventas
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> EditProductAsync(Product product);
        Task<Product> DeleteProductAsync(Guid id);

    }
}
