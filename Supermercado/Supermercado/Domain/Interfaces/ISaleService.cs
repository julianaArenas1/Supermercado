using System;


namespace Supermercado.Domain.Interfaces
{

    public class ISaleService
    {
        //Creación de métodos para Ventas
        Task<IEnumerable<Sale>> GetSaleAsync();
        Task<Sale> GetSaleByIdAsync(Guid id);
        Task<Sale> CreateSaleAsync(Sale sale);
        Task<Sale> EditSaleAsync(Sale sale);
        Task<sale> DeleteSaleAsync(Guid id);
    }

}
