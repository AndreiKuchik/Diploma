using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.Interface.Services;
using PLnew.Infrastructure.Mappers;
using PLnew.Models;

namespace PLnew.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserServices service;
         public HomeController()
        { }
         public HomeController(IUserServices service)
        {
            this.service = service;
         
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            Session["id"] = null;
            Session["idRole"] = null;
            if (ModelState.IsValid)
            {
                int id = service.Login(model.ToBllLogin());
                if (id>0)
                {
                    Session["id"] = id;
                    return RedirectToAction("Index", "Account");
                }
                else if (id==0)
                return View(model);
              
            }

            return View("Error");
        }


        public ActionResult Register()
        {
            return RedirectToAction("Register", "Account");

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}