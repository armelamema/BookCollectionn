using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCollectionn.Models
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Author
        public ActionResult Index()
        {
            var authors = _context.Authors.ToList();
            return View(authors);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Add(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }
    }
}