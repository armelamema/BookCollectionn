
using BookCollectionn.Models;
using System.Data.Entity.Migrations;

namespace BookCollectionn.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BookCollection.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookCollection.Models.ApplicationDbContext context)
        {
            // Seeding initial data for Authors
            context.Authors.AddOrUpdate(a => a.Name,
                new Author { Name = "J.K. Rowling" },
                new Author { Name = "George R.R. Martin" }
            );

            // Seeding initial data for Genres
            context.Set<Genre>().AddOrUpdate(g => g.Name,
                new Genre { Name = "Fantasy" },
                new Genre { Name = "Science Fiction" }
            );

          
            context.SaveChanges();
        }
    }
}