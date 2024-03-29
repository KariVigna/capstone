using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Authorize]
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
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            Kid thisKid = _db.Kids
                                .Include(kid => kid.Entries)
                                .FirstOrDefault(kid => kid.KidId == id);
            return View(thisKid);
        }

        public ActionResult Delete(int id)
        {
            Kid thisKid = _db.Kids.FirstOrDefault(kid => kid.KidId == id);
            return View(thisKid);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Kid thisKid = _db.Kids.FirstOrDefault(kid => kid.KidId == id);
            _db.Kids.Remove(thisKid);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ClearTotal(int kidId)
        {
            Kid thisKid = _db.Kids.FirstOrDefault(kid => kid.KidId == kidId);
            thisKid.Total = 0;
            _db.Kids.Update(thisKid);
            _db.SaveChanges();
            return RedirectToAction("Details", "Kids", new { id = thisKid.KidId });        }
    }
}