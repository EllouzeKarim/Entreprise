using Entreprise.Data;
using Entreprise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Entreprise.Controllers
{

    public class TeamsController : Controller
    {

        private Unit UnitOfWork;
        public TeamsController()
        {
            this.UnitOfWork = new Unit();
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Status") == "logged")
            {
                ViewData["role"] = this.UnitOfWork.User.getByID(Convert.ToInt32(HttpContext.Session.GetString("pid"))).ROLE;

                ViewData["logged"] = "true";
                return View((ICollection<Department>)this.UnitOfWork.Department.GetLIST());

            }
            return Redirect("/login");

        }
        public IActionResult Team(string id)
        {
            if (HttpContext.Session.GetString("Status") == "logged")
            {

                ViewData["role"] = this.UnitOfWork.User.getByID(Convert.ToInt32(HttpContext.Session.GetString("pid"))).ROLE;

                ViewData["logged"] = "true";
                ViewData["Dep"] = id;
                return View((List<User>)this.UnitOfWork.User.Find(x => x.Department.Name == id));

            }
            return Redirect("/login");

        }
        public IActionResult AllTeam(string id)
        {
            if (HttpContext.Session.GetString("Status") == "logged")
            {

                ViewData["role"] = this.UnitOfWork.User.getByID(Convert.ToInt32(HttpContext.Session.GetString("pid"))).ROLE;
                ViewData["logged"] = "true";
                return View((List<User>)this.UnitOfWork.User.GetAll());

            }
            return Redirect("/login");

        }
        public IActionResult Member(int id)
        {
            if (HttpContext.Session.GetString("Status") == "logged")
            {

                ViewData["role"] = this.UnitOfWork.User.getByID(Convert.ToInt32(HttpContext.Session.GetString("pid"))).ROLE;
                ViewData["logged"] = "true";
                return View((User)this.UnitOfWork.User.GetById(id));

            }
            return Redirect("/login");

        }

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Status") == "logged" && HttpContext.Session.GetString("role") == "CEO")
            {
                this.UnitOfWork.User.Remove((User)this.UnitOfWork.User.GetById(id));

                ViewData["logged"] = "true";
                this.UnitOfWork.complete();
                return RedirectToAction("AllTeam");
            }
            return Redirect("/login");
        }
        

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user= this.UnitOfWork.User.getByID(id);
            if(user == null)
            {
                return RedirectToAction("AllTeam");

            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User u)
        {
            if (HttpContext.Session.GetString("Status") == "logged")
            {
                this.UnitOfWork.User.updateUser(u.Id,u);
                return RedirectToAction("AllTeam");
            }

            return Redirect("/login");
        }


        [HttpGet]
        public IActionResult AddMember()
        {
            if (HttpContext.Session.GetString("Status") == "logged" && HttpContext.Session.GetString("role") == "CEO")
            {
                MyViewModel model = new MyViewModel();
                model.user = new User();

                model.did = 0;
                ViewData["role"] = this.UnitOfWork.User.getByID(Convert.ToInt32(HttpContext.Session.GetString("pid"))).ROLE;
                ViewData["logged"] = "true";
                return View();

            }
            return Redirect("/login");

        }
        [HttpPost]
        public IActionResult AddMember(MyViewModel model)
        {
            if (HttpContext.Session.GetString("Status") == "logged")
            {

                User user = new User();
                user.Id = model.user.Id;
                user.Firstname = model.user.Firstname;
                user.Lastname = model.user.Lastname;

                user.Email = model.user.Password;
                user.Password = model.user.Password;

                user.Phone_Number = model.user.Phone_Number;
                user.Function = model.user.Function ;
                user.ROLE = model.user.ROLE;
                user.Department = (Department) this.UnitOfWork.Department.GetById( model.did);
                this.UnitOfWork.User.Add(user);
                this.UnitOfWork.complete();
                return RedirectToAction("AllTeam");

            }
            return Redirect("/login");

        }
    }
}
