using Microsoft.AspNetCore.Mvc;

namespace ABCRetailWebApp.Controllers
{
    public class QueueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
