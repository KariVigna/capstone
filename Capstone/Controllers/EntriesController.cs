using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using System.Collections.Generic;
using System.Linq;


namespace Capstone.Controllers
{
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
                                    // .Include(entry => entry.Kid)
                                    .ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Entry entry)
        {
            _db.Entries.Add(entry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Entry thisEntry = _db.Entries.FirstOrDefault(entry => entry.EntryId == id);
            return View(thisEntry);
        }

        public ActionResult Edit(int id)
        {
            Entry thisEntry = _db.Entries.FirstOrDefault(entry => entry.EntryId == id);
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

        // public ActionResult AddReward(int id, int rewardAmt)
        // {
                // 1. use the id value to get the "Kid" from the database.
                // 2. then add the rewardAmount to the Kid's Total property.
                // 3. I have to decide which view to return.
                // 3. a. remember to grab any data that the view needs from the database.
                // 4. return view.
        //     Entry thisEntry = _db.Entries.FirstOrDefault(entry => entry.EntryId == id);
            // Kid thisKid = _db.Kids.FirstOrDefault(kid => kid.KidId == id);
            // thisKid.Total += rewardAmt;
            // _db.SaveChanges();
            // return RedirectToAction("Index");

        //     if (reward != 0) {
        //         _db.Entry
        //     }
        // }

        // }
    }
}