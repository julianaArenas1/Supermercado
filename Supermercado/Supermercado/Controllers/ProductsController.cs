using Microsoft.AspNetCore.Mvc;
using Supermercado.DAL.Entities;
using Supermercado.Domain.Interfaces;

namespace Supermercado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        
            private readonly IProductService _productService;


           public ProductsController(IProductService productService)
            { 
            _productService = productService;
              }

            [HttpGet, ActionName("Get")]
            [Route("GetAll")]
            public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
             {
                var products = await _productService.GetProductsAsync();
                if (products == null || !products.Any())
                {
                    return NotFound();
                }
                return Ok(products);
            }

        [HttpGet, ActionName("Get")]
        [Route("GetId/{id}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost, ActionName("Create")]
            [Route("Create")]
            public async Task<ActionResult<Product>> CreateProductAsync(Product product)
             {
                try
                {

                    var newProduct = await _categoryService.CreateProductAsync(product);
                    if (newProduct == null)
                    {
                        return NotFound();
                    }
                    return Ok(newProduct);
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
            public async Task<ActionResult<Product>> EditProductAsync(Product product)
            {
                try
                {
                    var editedProduct = await _productService.EditProductAsync(product);
                    if (editedProduct == null)
                    {
                        return NotFound();
                    }
                    return Ok(editedProduct);
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
            public async Task<ActionResult<Product>> DeleteProductAsync(Guid id)
            {

                var deletedProduct = await _categoryProduct.DeleteProductAsync(id);
                if (deletedProduct == null)
                {
                    return NotFound();
                }
                return Ok(deletedProduct);
            }

        
    }
}
