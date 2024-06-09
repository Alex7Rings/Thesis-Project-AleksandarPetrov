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


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
