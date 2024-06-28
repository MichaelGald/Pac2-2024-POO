using BlogUNAHApi.Database.Entities;
using BlogUNAHApi.Dtos.Categories;
using Microsoft.EntityFrameworkCore;

namespace BlogUNAHApi.Database
{
    public class BlogUNAHContext : DbContext
    {
        public BlogUNAHContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<PostEntity> Post { get; set; }
        public DbSet<PostTagEntity> PostTags { get; set; }
    }
}
