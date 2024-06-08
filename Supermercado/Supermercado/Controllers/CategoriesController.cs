using Microsoft.AspNetCore.Mvc;
using Supermercado.DAL.Entities;
using Supermercado.Domain.Interfaces;

namespace Supermercado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;


        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            if (categories == null || !categories.Any())
            {
                return NotFound();
            }
            return Ok(categories);
        }
        [HttpGet, ActionName("Get")]
        [Route("GetId/{id}")]
        public async Task<ActionResult<Category>> GetCategoryByIdAsync(Guid id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Category>> CreateCategoryAsync(Category category)
        {
            try
            {

               var newCategory = await _categoryService.CreateCategoryAsync(category);
                if (newCategory == null) { 
                return NotFound();
                }
                return Ok(newCategory);
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(string.Format("{0} ya existe", category.categoryName));
                    return Conflict(ex.Message);
                }
            }
        }
        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Category>> EditCategoryAsync(Category category)
        {
            try
            {
                var editedCategory = await _categoryService.EditCategoryAsync(category);
                if(editedCategory == null)
                {
                    return NotFound();
                }
                return Ok(editedCategory);
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(string.Format("{0} ya existe", category.categoryName));
                    return Conflict(ex.Message);
                }
            }
        
        }
        [HttpPut, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Category>> DeleteCategoryAsync(Guid id)
        {
           
                var deletedCategory = await _categoryService.DeleteCategoryAsync(id);
                if (deletedCategory == null)
                {
                    return NotFound();
                }
                return Ok(deletedCategory);
          
           

        }
    }
}
