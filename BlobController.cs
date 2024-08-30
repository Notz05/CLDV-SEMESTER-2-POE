using ABCRetailWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABCRetailWebApp.Controllers
{
    public class BlobController : Controller
    {
        private readonly BlobService _blobService;

        public BlobController(BlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var images = await _blobService.ListImagesAsync("ProductImages");
            return View(images);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    await _blobService.UploadBlobAsync("ProductImages", file.FileName, stream);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
