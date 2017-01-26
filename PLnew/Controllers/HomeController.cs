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
            if (ModelState.IsValid)
            {
                PersonViewModel person = service.Login(model.ToBllLogin()).ToPLUser();
                if (person.Id>0)
                {
                    return RedirectToAction("Index", "Account",person);
                }
                return View(model);
              
            }

            return View();
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