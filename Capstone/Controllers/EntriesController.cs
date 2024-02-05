using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Capstone.Models;
using System.Collections.Generic;
using System.Linq;

namespace Capstone.Controllers
{
    public class TasksController : Controller
    {
        private readonly CapstoneContext _db;
        public TasksController(CapstoneContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            return View(_db.Entries.ToList());
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
    }
}