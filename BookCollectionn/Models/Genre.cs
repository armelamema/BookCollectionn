using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCollectionn.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }
}