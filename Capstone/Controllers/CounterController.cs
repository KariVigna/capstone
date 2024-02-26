using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class CounterController : Controller{
        public IActionResult Index()
        {
            return View();
        }

        
    }
}