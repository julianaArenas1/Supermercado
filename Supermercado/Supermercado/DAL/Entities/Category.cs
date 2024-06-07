using System.ComponentModel.DataAnnotations;

namespace Supermercado.DAL.Entities
{
    public class Category : AuditBase
    {

        [Display(Name = "Categoría")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string categoryName { get; set; } = null!;


        [Display(Name = "Foto")]
        public string Image { get; set; } = null!;

        public ICollection<Product>? Products { get; set; }
    }
}
