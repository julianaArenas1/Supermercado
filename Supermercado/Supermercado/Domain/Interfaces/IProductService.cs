namespace Supermercado.Domain.Interfaces
{
    public class IProductService
    {
        //Creación de los métodos para productos
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> EditProductAsync(Product product);
        Task<Product> DeleteProductAsync(Guid id);
    }
}
