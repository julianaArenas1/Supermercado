using Supermercado.DAL.Entities;
using System.Diagnostics.Metrics;

namespace Supermercado.Domain.Interfaces
{

    public interface ISaleService
    {
        //Creación de métodos para Ventas
        Task<IEnumerable<Sale>> GetSaleAsync();
        Task<Sale> GetSaleByIdAsync(Guid id);
        Task<Sale> CreateSaleAsync(Sale sale);
        Task<Sale> EditSaleAsync(Sale sale);
        Task<Sale> DeleteSaleAsync(Guid id);
    }

}
