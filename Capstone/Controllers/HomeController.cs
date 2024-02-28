using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Capstone.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Diagnostics.Metrics;


namespace Capstone.Controllers
{

    public class HomeController : Controller
    {
        private readonly CapstoneContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, CapstoneContext db)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet("/")]
        public ActionResult Index()
        {
            Entry[] entries = _db.Entries.ToArray();
            Dictionary<string,object[]> model = new Dictionary<string, object[]>();
            model.Add("entries", entries);
            return View(model);
        }
    }
}