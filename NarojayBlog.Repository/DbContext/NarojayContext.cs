using Microsoft.EntityFrameworkCore;
using NarojayBlog.DatabaseRepository.Model;

namespace NarojayBlog.DatabaseRepository.DbContext
{
    public class NarojayContext :Microsoft.EntityFrameworkCore.DbContext
    {
        public NarojayContext(DbContextOptions<NarojayContext> options) : base(options)
        {
            
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<GuestBook> Guestbooks { get; set; }
    }
}
