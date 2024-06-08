using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Supermercado.DAL.Entities
{
    public class Sale : AuditBase
    {
        [Display(Name = "NIT Supermercado")]
        public int supermarketID { get; set; }


        [Display(Name = "ID - usuario")]
        public int userID { get; set; }


        [Display(Name = "Pago confirmado")]
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public bool Status { get; set; }

        //tipo_pago

        [Display(Name = "Tipo pago")]
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public bool paymentType { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Monto ingresado")]
        public decimal? enterAmount { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Monto total")]
        public decimal? totalPayment { get; set; }


        [Display(Name = "Producto")]
        public ICollection<ProductSale>? ProductSales { get; set; }
    }
}
