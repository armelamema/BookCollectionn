using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCollectionn.Models
{
    public class Genre
    {
        [Key] // This marks GenreId as the primary key
        public int GenreId { get; set; } // Unique ID for each genre

        [Required(ErrorMessage = "Genre name is required.")]
        [StringLength(100, ErrorMessage = "Genre name cannot exceed 100 characters.")]
        public string Name { get; set; } // Name of the genre

        // This creates a list of books that belong to this genre
        public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}
