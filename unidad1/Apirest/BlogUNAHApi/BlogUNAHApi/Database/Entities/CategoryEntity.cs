using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogUNAHApi.Database.Entities
{
    [Table("categories", Schema = "dbo")]
    public class CategoryEntity : BaseEntity
    {
        // Data Annotetions
        [Display(Name = "Nombre")]
        [Required(ErrorMessage ="El {0} de la categoria es requerido.")]
        [StringLength(50)]
        [Column("name")]
        public string Name { get; set; }

        [Display(Name = "Descripcion")]
        [MinLength(10, ErrorMessage = "La {0} debe tener al menos {1} caracteres.")]
        [StringLength(250)]
        [Column("description")]
        public string Description { get; set; }

        public virtual IEnumerable<PostEntity> Posts { get; set; }
    }
}
