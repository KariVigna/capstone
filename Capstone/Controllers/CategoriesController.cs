using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Capstone.Models;
using System.Collections.Generic;
using System.Linq;

namespace Capstone.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CapstoneContext _db;
        public CategoriesController(CapstoneContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            return View(_db.Categories.ToList());
        }
    }
}