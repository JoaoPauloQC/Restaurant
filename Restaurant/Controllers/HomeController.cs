using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Pedido(int ID, string less = "dn")
        {
            ViewData["less_class"] = less;

            ViewData["Mesa"] = ID;
            
            return View();
        }


        [HttpPost]
        public IActionResult Validate(string pedido , int ID)
        {

            Console.WriteLine(pedido);
            if (pedido == "burguer")
            {
                ViewData["Mesa"] = ID;
                ViewData["Pedido"] = pedido;
                return View();
            }
            else
            {
                return RedirectToAction("Pedido" , new { less = "less"});
            }
        }
    }
}
