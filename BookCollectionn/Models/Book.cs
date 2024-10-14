using BookCollectionn.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;



namespace BookCollectionn.Models
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Book
        public ActionResult Index()
        {
            var books = _context.Books.Include(b => b.Author).ToList();
            return View(books);
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
}

