using BookCollectionn.Models;
using System.Data.Entity.Migrations;

namespace BookCollectionn.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using BookCollectionn.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BookCollectionn.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookCollectionn.Models.ApplicationDbContext context)
        {
            // Seeding initial data for Authors
            context.Authors.AddOrUpdate(a => a.Name,
                new Author { Name = "J.K. Rowling" },
                new Author { Name = "George R.R. Martin" }
            );

            // Seeding initial data for Genres
            context.Genres.AddOrUpdate(g => g.Name,
                new Genre { Name = "Fantasy" },
                new Genre { Name = "Science Fiction" }
            );

            // Commit the changes to the database
            context.SaveChanges();
        }
    }
}

