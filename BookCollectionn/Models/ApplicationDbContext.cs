using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookCollectionn.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        // Method to configure relationships between models
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Define composite key for the BookGenre many-to-many relationship
            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookID, bg.GenreID });

            // Configure relationships between BookGenre and Book
            _ = modelBuilder.Entity<BookGenre>()
                .HasRequired(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookID);

            // Configure relationships between BookGenre and Genre
            modelBuilder.Entity<BookGenre>()
                .HasRequired(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreID);
        }
    }
}
