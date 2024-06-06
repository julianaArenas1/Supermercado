using Supermercado.DAL.Entities;
using Supermercado.Entities;

namespace Supermercado.Entities
{
    public class ProductSale
    {
        public int saleId { get; set; }
        public Sale Sale { get; set; }
        public int productId { get; set; }
        public Product Product { get; set; }
        public int? Quantity { get; set; }
    }
}
