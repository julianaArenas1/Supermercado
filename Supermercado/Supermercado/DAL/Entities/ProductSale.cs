namespace Supermercado.DAL.Entities
{
    public class ProductSale
    {
        public Guid saleId { get; set; }
        public Sale Sale { get; set; }
        public Guid productId { get; set; }
        public Product Product { get; set; }
        public int? Quantity { get; set; }
    }
}