using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogUNAHApi.Database.Entities
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [StringLength(100)]
        [Column("created_by")]
        public string CreateBy { get; set; }
        [Column("created_date")]
        public DateTime CretedDate { get; set; }
        [StringLength(100)]
        [Column("update_by")]
        public string UpdateBy { get; set; }
        [Column("update_date")]
        public DateTime UpdateDate { get; set; }

        //public bool IsDeleted { get; set; }
    }
}
