using Microsoft.AspNetCore.Mvc;
using Supermercado.DAL.Entities;
using Supermercado.Domain.Interfaces;
using Supermercado.Domain.Services;
using System.Diagnostics.Metrics;


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
            var sales = await _saleService.GetSaleAsync();
            if (sales == null || !sales.Any())
            {
                return NotFound();
            }
            return Ok(sales);
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
        [Route("New Sale")]
        public async Task<ActionResult<Sale>> CreateSaleAsync(Sale sale)
        {
            try
            {
                var newSale = await _saleService.CreateSaleAsync(sale);
                if (newSale == null) return NotFound();
                return Ok(newSale);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", sale.Id));

                return Conflict(ex.Message);
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
