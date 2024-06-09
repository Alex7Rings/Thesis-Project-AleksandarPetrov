using ImageClassificationApp.Web.Models;
using ImageClassificationApp_Web;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ImageClassificationApp.Web.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

		[HttpGet]
		public IActionResult SportImages()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ClassifyImage(IFormFile file)
		{
			if (file == null || file.Length == 0)
				return Content("file not selected");

			var fileName = $"{Guid.NewGuid()}_{file.FileName}";
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

			Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads"));

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			byte[] imageBytes;
			using (var memoryStream = new MemoryStream())
			{
				await file.CopyToAsync(memoryStream);
				imageBytes = memoryStream.ToArray();
			}

			var sampleData = new MLModel_Sport.ModelInput { ImageSource = imageBytes };
			var result = MLModel_Sport.Predict(sampleData);

			float accuracy = result.Score.Max();

			ViewData["ImagePath"] = $"/uploads/{fileName}";
			ViewData["Accuracy"] = accuracy;
			return View("SportImagesResult", result);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
