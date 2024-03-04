using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Capstone.Controllers
{
    public class KidsController : Controller
    {
        private readonly CapstoneContext _db;
        public KidsController(CapstoneContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Kid> model = _db.Kids.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kid kid)
        {
            _db.Kids.Add(kid);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Kid thisKid = _db.Kids
                                .Include(kid => kid.Entries)
                                .FirstOrDefault(kid => kid.KidId == id);
            return View(thisKid);
        }
    }
}