using Microsoft.AspNetCore.Mvc;
using Supermercado.DAL.Entities;
using Supermercado.Domain.Interfaces;

namespace Supermercado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : Controller
    {
       private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;        
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSalesAsync()
        {
            var sales = await _saleService.GetSalesAsync();
            if (sales == null || !sales.Any())
            {
                return NotFound();
            }
            return Ok(Sales);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetId/{id}")]
        public async Task<ActionResult<Sale>> GetSaleByIdAsync(Guid id)
        {
            var sale = await _saleService.GetSaleByIdAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Sale>> CreateSaleAsync(Sale sale)
        {
            try
            {

                var newSale = await _saleService.CreateCategoryAsync(sale);
                if (newSale == null)
                {
                    return NotFound();
                }
                return Ok(newSale);
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
        public async Task<ActionResult<Sale>> EditSaleAsync(Sale sale)
        {
            try
            {
                var editedSale = await _saleService.EditSaleAsync(sale);
                if (editedSale == null)
                {
                    return NotFound();
                }
                return Ok(editedSale);
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
        public async Task<ActionResult<Sale>> DeleteSaleAsync(Guid id)
        {

            var deletedSale = await _saleService.DeleteSaleAsync(id);
            if (deletedSale== null)
            {
                return NotFound();
            }
            return Ok(deletedSale);



        }
    }
}
