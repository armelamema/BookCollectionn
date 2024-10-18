using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCollectionn.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public ICollection<BookCollection.Controllers.Book> Books { get; set; }
    }
}