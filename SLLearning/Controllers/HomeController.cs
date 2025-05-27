using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SLLearning.Models;

namespace SLLearning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public class PrivacyVM
        {
            public int PaymentTypeId { get; set; }

            public SelectList PaymentTypes { get; set; }

            public string Message { get; set; }
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            object[] types = [
              new { Id = 1, Name = "Cash" },
              new { Id = 2, Name = "Credit" }
            ];
            var m = new PrivacyVM();

            m.PaymentTypes = new SelectList(types, "Id", "Name");
  
            return View(m);
        }


        [HttpPost]
        public IActionResult Privacy(PrivacyVM m)
        {
            //if valid persist redirect to index

            object[] types = [ new { Id = 1, Name = "Cash" }, new { Id = 2, Name = "Credit" }];
            m.PaymentTypes = new SelectList(types, "Id", "Name");
            return View(m);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
