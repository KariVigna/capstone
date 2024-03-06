using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Authorize]
    public class EntriesController : Controller
    {
        private readonly CapstoneContext _db;
        public EntriesController(CapstoneContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Entry> model = _db.Entries
                                    .Include(entry => entry.Kid)
                                    .ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.KidId = new SelectList(_db.Kids, "KidId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Entry entry)
        {
            if (entry.KidId == 0)
            {
                return RedirectToAction("Create");
            }
            _db.Entries.Add(entry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Entry thisEntry = _db.Entries
                                    .Include(entry => entry.Kid)
                                    .FirstOrDefault(entry => entry.EntryId == id);
            return View(thisEntry);
        }

        public ActionResult Edit(int id)
        {
            Entry thisEntry = _db.Entries.FirstOrDefault(entry => entry.EntryId == id);
            ViewBag.KidId = new SelectList(_db.Kids, "KidId", "Name");
            return View(thisEntry);
        }

        [HttpPost]
        public ActionResult Edit(Entry entry)
        {
            _db.Entries.Update(entry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Entry thisEntry = _db.Entries.FirstOrDefault(entry => entry.EntryId == id);
            return View(thisEntry);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Entry thisEntry = _db.Entries.FirstOrDefault(entry => entry.EntryId == id);
            _db.Entries.Remove(thisEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // [HttpGet]
        // public ActionResult ViewCompleted()
        // {
        //     List<Entry> model = _db.Entries.ToList();
        //     return View(model);
        // }

        public ActionResult TaskCompleted(int entryId){

            Entry thisEntry = _db.Entries.FirstOrDefault(entry => entry.EntryId == entryId);
            Kid thisKid = _db.Kids.FirstOrDefault(kid => kid.KidId == thisEntry.KidId);
            thisEntry.IsComplete = true;
            thisKid.Total += thisEntry.Reward;
            _db.Entries.Update(thisEntry);
            _db.Kids.Update(thisKid);
            _db.SaveChanges();
            return RedirectToAction("Details", "Kids", new { id = thisKid.KidId });
        }

        public ActionResult TaskUnCompleted(int entryId){

            Entry thisEntry = _db.Entries.FirstOrDefault(entry => entry.EntryId == entryId);
            Kid thisKid = _db.Kids.FirstOrDefault(kid => kid.KidId == thisEntry.KidId);
            thisEntry.IsComplete = false;
            thisKid.Total -= thisEntry.Reward;
            _db.Entries.Update(thisEntry);
            _db.Kids.Update(thisKid);
            _db.SaveChanges();
            return RedirectToAction();
        }
    }
}