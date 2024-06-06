using Supermercado.DAL.Entities;
using System.Diagnostics.Metrics;

namespace Supermercado.Domain.Interfaces 
{ 
    public interface ICategoryService
    {
        //Creación de los métodos de categoría
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> EditCategoryAsync(Category category);
        Task<Category> DeleteCategoryAsync(Guid id);
    }
}
