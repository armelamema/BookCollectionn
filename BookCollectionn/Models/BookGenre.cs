using BookCollectionn.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCollectionn.Models
{
    public class BookGenre
    {
        public int BookID { get; set; }
        public virtual Book Book { get; set; }

        public int GenreID { get; set; }
        public virtual BookGenre Genre { get; set; }
        public ICollection<BookGenre> BookGenres { get; internal set; }
    }
}