using Microsoft.EntityFrameworkCore;
using Supermercado.DAL;
using Supermercado.DAL.Entities;
using Supermercado.Domain.Interfaces;

namespace Supermercado.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataBaseContext _context;

        public CategoryService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            return categories;
        }
        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            category.Id = Guid.NewGuid();
            category.CreatedDate = DateTime.Now;        
            _context.Categories.Add(category);
           await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> EditCategoryAsync(Category category)
        {
            
                category.ModifiedDate = DateTime.Now;
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                return category;
           
        }

        public async Task<Category> DeleteCategoryAsync(Guid id)
        {
            var category = await GetCategoryByIdAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return category;
            }
            return null;
        }

      

       

      
    }
}
