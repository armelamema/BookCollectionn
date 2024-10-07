using BookCollectionn.Models;
using System.Data.Entity.Migrations;

namespace BookCollectionn.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookCollectionn.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookCollectionn.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
protected override void Seed(BookCollectionn.Models.ApplicationDbContext context)
{
    context.Authors.AddOrUpdate(a => a.Name,
        new Author { Name = "J.K. Rowling" },
        new Author { Name = "George R.R. Martin" });

    context.Genres.AddOrUpdate(g => g.Name,
        new Genre { Name = "Fantasy" },
        new Genre { Name = "Science Fiction" });

    context.SaveChanges();
}

