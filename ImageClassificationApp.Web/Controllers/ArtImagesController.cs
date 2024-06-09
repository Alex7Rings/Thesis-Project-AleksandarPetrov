using ImageClassificationApp_Web;
using Microsoft.AspNetCore.Mvc;

namespace ImageClassificationApp.Web.Controllers
{
    public class ArtImagesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
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

            var sampleData = new MLModel_Art.ModelInput { ImageSource = imageBytes };
            var result = MLModel_Art.Predict(sampleData);

            // Translate the predicted label
            result.PredictedLabel = MLModel_Art.TranslateLabel(result.PredictedLabel);

            float accuracy = result.Score.Max();

            ViewData["ImagePath"] = $"/uploads/{fileName}";
            ViewData["Accuracy"] = accuracy;
            return View("Result", result);
        }
    }
}
