using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookCollectionn.Models
{
    public class Book
    {
        public int BookID { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public int AuthorID { get; set; } 
        public virtual Author Author { get; set; } 

        public string Genre { get; set; }
        public ICollection<BookGenre> BookGenres { get; internal set; }
    }
}
