using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCollectionn.Models
{
    public class BookGenre
    {
        public int BookID { get; set; }
        public int GenreID { get; set; }


        public virtual Book Book { get; set; }
        public virtual Genre Genre { get; set; }
    }
}