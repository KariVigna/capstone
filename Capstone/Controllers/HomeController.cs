using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Capstone.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Security.Claims;


namespace Capstone.Controllers
{

    public class HomeController : Controller
    {
        private readonly CapstoneContext _db;
        public HomeController(CapstoneContext db)
        {
            _db = db;
        }

        [HttpGet("/")]
        public ActionResult Index()
        {
            // Entry entry = new Entry();
            Entry[] entries = _db.Entries.ToArray();
            Dictionary<string,object[]> model = new Dictionary<string, object[]>();
            model.Add("entries", entries);
            // List<Entry> model = new List<Entry>();
            // model.Add(entries);
            return View(model);
        }

    }
}