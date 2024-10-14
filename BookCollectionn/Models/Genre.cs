using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCollectionn.Models
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Genre
        public ActionResult Index()
        {
            var genres = _context.Genres.ToList();
            return View(genres);
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _context.Genres.Add(genre);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }
    }
}