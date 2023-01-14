using Entreprise.Data;
using Entreprise.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Entreprise.Controllers
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
            if (HttpContext.Session.GetString("Status") == "logged")
            {
                
                ViewData["logged"] = "true";
                return View();

            }
            return Redirect("/login");
            
        }
         
    }
}