using Microsoft.AspNetCore.Mvc;

namespace ABCRetailWebApp.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
