using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Entreprise.Controllers
{
    public class TasksController : Controller
    {
        // GET: TasksController
        public ActionResult Index()
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
