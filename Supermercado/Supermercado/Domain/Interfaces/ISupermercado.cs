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
        Task<IEnumerable<Category>> GetCategorysAsync();
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> EditCategoryAsync(Category category);
        Task<Category> DeleteCategoryAsync(Guid id);

        //Creación de métodos para Ventas
        Task<IEnumerable<Sale>> GetSaleAsync();
        Task<Sale> GetSaleByIdAsync(Guid id);
        Task<Sale> CreateSaleAsync(Sale sale);
        Task<Sale> EditSaleAsync(Sale sale);
        Task<sale> DeleteSaleAsync(Guid id);

    }
}
