using Microsoft.AspNetCore.Mvc;

namespace ABCRetailWebApp.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
