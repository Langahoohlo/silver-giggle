using baseapp.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace baseapp.Data
{
    public class BloggieDbContext : DbContext
    {
        public BloggieDbContext(DbContextOptions options) : base(options)
        {

        }
        // Creating tables for blogpost and Tags
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
