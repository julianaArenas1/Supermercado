using Supermercado.DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
namespace Supermercado.Entities;

    public class Product : AuditBase
    {
        [Display(Name = "Producto")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string productName { get; set; } = null!;

        [Required]
        public int categoryId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Precio sugerido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public double suggestedPrice { get; set; }


        [Display(Name = "Marca")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string Brand { get; set; } = null!;


        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Display(Name = "Disponibilidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Stock { get; set; }


        [Display(Name = "Foto")]
        public string Image { get; set; } = null!;


        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Description { get; set; } = null!;

        public IEnumerable<ProductSale>? ProductSales { get; set; }
    }
