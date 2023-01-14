using Entreprise.Data;
using Entreprise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Entreprise.Controllers
{
    public class LoginController : Controller
    {
        
        private Unit UnitOfWork;
        private int pid;
        public LoginController() {

            this.UnitOfWork = new Unit();
        }
        [HttpGet]
        public ActionResult Index(string id)
        {
            if (HttpContext.Session.GetString("Status") != "logged")
            {
                if (id != "")
                {
                    ViewData["Error"] = id;
                }
                return View();
            }
            else
            {
                return Redirect("/home");

            }
        } 

        [HttpPost]
        public ActionResult Index(User user)
        {
            User u= (User)UnitOfWork.User.getByEmail(user.Email);
            if( u==null) {  
                return RedirectToAction("Index", new { id = "Wrong Email! Please Try Again" });
            }
            else if (u.Password!=user.Password)
            { 
                return RedirectToAction("Index", new { id =" Wrong Password! Please Try Again" });
            }
            else {
            HttpContext.Session.SetString("Status", "logged");
                HttpContext.Session.SetString("pid", u.Id.ToString());
                HttpContext.Session.SetString("role",u.ROLE);


            return Redirect ("/home" );
            }
        } 

        public ActionResult Profile()
        {
            if(HttpContext.Session.GetString("Status") == "logged")
            {
                ViewData["logged"] = "true";

                return View(this.UnitOfWork.User.getByID(Convert.ToInt32( HttpContext.Session.GetString("pid"))));

            }
            return Redirect("/login");
        }
        public ActionResult Logout()
        {
            HttpContext.Session.SetString("Status", "");
            HttpContext.Session.SetString("pid", "");
            HttpContext.Session.SetString("role", "");
            return RedirectToAction("Index");
        }

        
      
    }
}
