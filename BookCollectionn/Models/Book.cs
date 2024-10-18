using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using BookCollectionn.Models;
using System.Collections.Generic;  

namespace BookCollectionn.Controllers  
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Book
        public ActionResult Index()
        {
            return View(_context.Books.Include("Author").ToList());
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(_context.Authors, "AuthorID", "Name");
            ViewBag.Genres = new MultiSelectList(_context.Genres, "GenreID", "Name");
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book, int[] selectedGenres)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();

                // Add selected genres to the book
                if (selectedGenres != null)
                {
                    foreach (var genreId in selectedGenres)
                    {
                        var bookGenre = new BookGenre { BookID = book.BookID, GenreID = genreId };
                        _context.BookGenres.Add(bookGenre);
                    }
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(_context.Authors, "AuthorID", "Name", book.AuthorID);
            ViewBag.Genres = new MultiSelectList(_context.Genres, "GenreID", "Name", selectedGenres);
            return View(book);
        }
    }

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }  
        public DbSet<BookGenre> BookGenres { get; set; }
    }
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }
}
