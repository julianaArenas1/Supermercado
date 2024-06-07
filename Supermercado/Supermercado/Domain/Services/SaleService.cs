using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using Supermercado.DAL;
using Supermercado.DAL.Entities;
using Supermercado.Domain.Interfaces;

namespace Supermercado.Domain.Services
{
    public class SaleService : ISaleService
    {
        private readonly DataBaseContext _context;

        public SaleService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sale>> GetSaleAsync()
        {
            var sales = await _context.Sales.ToListAsync();

            return sales;
        }
        public async Task<Sale> GetSaleByIdAsync(Guid id)
        {
            var sale = await _context.Sales.FirstOrDefaultAsync(s => s.Id == id);
            return sale;
        }

        public async Task<Sale> CreateSaleAsync(Sale sale)
        {
            sale.Id = Guid.NewGuid();
            sale.CreatedDate = DateTime.Now;
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task<Sale> DeleteSaleAsync(Guid id)
        {
            var sale = await GetSaleByIdAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
                return sale;
            }
            return null;
        }

        public async Task<Sale> EditSaleAsync(Sale sale)
        {
            sale.ModifiedDate = DateTime.Now;
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

       

      
    }
}
