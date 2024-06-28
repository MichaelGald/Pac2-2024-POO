using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogUNAHApi.Database.Entities
{
    [Table("posts", Schema = "dbo")]
    public class PostEntity : BaseEntity
    {
        [StringLength(100)]
        [Required]
        [Column("title")]
        public string Title { get; set; }
        //Detfinir la relacion entre usuario y post
        [StringLength(100)]
        [Column("author_id")]
        public string AuthorId { get; set; }
        [Column("publication_date")]
        public DateTime PublicationDate { get; set; }

        [Column("categoru_id")]
        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual CategoryEntity Category  { get; set; }

        [Column("content")]
        public string Content { get; set; }

        public virtual IEnumerable<PostTagEntity> Tags { get; set; }
    }
}
