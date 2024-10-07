using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookCollectionn.Models
{
    public class Author
    {
        public int AuthorID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}