using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookCollection.Models;

namespace BookCollection.Controllers
{
    public class BookController : Controller
    {
        private readonly BookContext _context;

        public BookController()
        {
            _context = new BookContext();
        }

        // GET: Book/Index
        public ActionResult Index()
        {
            var books = _context.Books; 
            if (books == null)
            {
                
                return View(new List<Book>());
            }
            var bookList = books.ToList(); 
            return View(bookList);
        }

       

    public class BookContext : DbContext 
    {
        public BookContext() : base("YourConnectionStringName")
        {
        }

        public DbSet<Book> Books { get; set; } 
    }

    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; } 
        public int AuthorID { get; set; }
        
    }
}
