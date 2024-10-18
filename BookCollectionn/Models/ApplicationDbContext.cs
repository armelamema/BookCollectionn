using BookCollection.Controllers;
using BookCollectionn.Controllers;
using BookCollectionn.Models;
using System.Data.Entity;

namespace BookCollection.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        public ApplicationDbContext() : base("name=YourConnectionStringName")
        {
        }
    }
}
