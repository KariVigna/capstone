using Microsoft.AspNetCore.Mvc;
using Capstone.Models;

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
            // Entry[] entries = _db.Entries.ToArray();
            // Kid[] kids = _db.Kids.ToArray();
            // Dictionary<string,object[]> model = new Dictionary<string, object[]>();
            // model.Add("entries", entries);
            // model.Add("kids", kids);
            return View();
        }
    }
}