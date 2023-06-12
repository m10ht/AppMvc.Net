using Microsoft.AspNetCore.Mvc;

namespace App.Controllers {
    
    public class FirstController : Controller {
        private readonly ILogger<FirstController> _logger;
        IWebHostEnvironment _webHostEnvironment;
        public FirstController(ILogger<FirstController> logger, IWebHostEnvironment webHostEnvironment) {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }
        public string Index() {
            _logger.LogInformation("LOggggg FirstController");
            return "First Controller";
        }
        public void Nothing() {
            Console.WriteLine("Xin chao cac ban");
            Response.Headers.Add("HelloWorld", "VNChampions");
        }
        public IActionResult Image() {
            string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Files", "a.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "image/jpg");
        }

        public IActionResult MyView(string userName) {
            if (string.IsNullOrEmpty(userName))
                userName = "MYLOVE";
            return View("/MyView/myview.cshtml", userName);
        }
        public IActionResult ViewProduct(int id) {
            return Redirect(Url.Action("Index", "Home"));
            // return Content($"ID: {id}");
        }
    }
}