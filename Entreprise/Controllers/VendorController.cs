using Entreprise.Data;
using Entreprise.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entreprise.Controllers
{
    public class VendorController : Controller
    {
        private Unit UnitOfWork;
        public VendorController()
        {
            this.UnitOfWork = new Unit();
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Status") == "logged")
            {
                ViewData["role"] = this.UnitOfWork.User.getByID(Convert.ToInt32(HttpContext.Session.GetString("pid"))).ROLE;
                ViewData["logged"] = "true";
                return View(this.UnitOfWork.Vendor.GetAll());

            }
            return Redirect("/login");
        }
        public IActionResult VendorProducts(int id)
        {
            if (HttpContext.Session.GetString("Status") == "logged")
            {
                ViewData["role"] = this.UnitOfWork.User.getByID(Convert.ToInt32(HttpContext.Session.GetString("pid"))).ROLE;
                ViewData["logged"] = "true";
                return View(this.UnitOfWork.Product.GetbyVendor(this.UnitOfWork.Vendor.GetById(id)));
                //return View(this.UnitOfWork.Vendor.GetById(id).Products);
            }
            return Redirect("/login");
        }

        public IActionResult DeleteVendor(int id)
        {
            if (HttpContext.Session.GetString("Status") == "logged" && HttpContext.Session.GetString("role") == "CEO")
            {

                this.UnitOfWork.Vendor.Remove((Vendor)this.UnitOfWork.Vendor.GetById(id));
                ViewData["logged"] = "true";
                this.UnitOfWork.complete();
                return RedirectToAction("Index");
            }
            return Redirect("/login");

        }
        [HttpGet]
        public IActionResult CreateVendor()
        {
            if (HttpContext.Session.GetString("Status") == "logged" && HttpContext.Session.GetString("role") == "CEO")
            {

                ViewData["logged"] = "true";
                this.UnitOfWork.complete();
                return View();
            }
            return Redirect("/login");
        }
        [HttpPost]
        public IActionResult CreateVendor(Vendor v)
        {
            if (HttpContext.Session.GetString("Status") == "logged" && HttpContext.Session.GetString("role") == "CEO")
            {
                this.UnitOfWork.Vendor.Add(v);
                ViewData["logged"] = "true";
                this.UnitOfWork.complete();
                return RedirectToAction("Index");
            }
            return Redirect("/login");
        }
        [HttpGet]
        public IActionResult EditVendor(int id)
        {
            if (HttpContext.Session.GetString("Status") == "logged" && HttpContext.Session.GetString("role") == "CEO")
            {

                ViewData["logged"] = "true";

                return View(this.UnitOfWork.Vendor.GetById(id));

            }
            return Redirect("/login");
        }

        [HttpPost]
        public IActionResult EditVendor(Vendor v)
        {
            if (HttpContext.Session.GetString("Status") == "logged" && HttpContext.Session.GetString("role") == "CEO")
            {
                this.UnitOfWork.Vendor.UpdateVendor(v);
                this.UnitOfWork.complete();
                return RedirectToAction("Index");

            }
            return Redirect("/login");
        }

    }
}
