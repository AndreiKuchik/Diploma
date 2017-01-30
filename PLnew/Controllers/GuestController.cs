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
    public class GuestController : Controller
    {
        private readonly IUserServices service;
        private readonly IThemeServices themeServices;
        private readonly IRecordService recordService;
        //private static PersonViewModel guestModel { get; set; }


          public GuestController()
        { }
          public GuestController(IUserServices service, IThemeServices themeServices, IRecordService recordService)
        {
            this.service = service;
            this.themeServices = themeServices;
            this.recordService = recordService;

        }
        //
        // GET: /Guest/
        public ActionResult Index(int id=0)
        {
            if (id != 0)
            {
                Session["idGuest"] = id;
                PersonViewModel guestModel = service.GetById(id).ToPLUser();
                ViewBag.Status = service.GetSubscribe(Convert.ToInt32(Session["id"]),id);
                return View(guestModel);
            }
            return View(service.GetById(Convert.ToInt32(Session["idGuest"])).ToPLUser());
        }

        public ActionResult ShowRecordsListNull()
        {
            ViewBag.Id = Session["id"];
            return PartialView("_ShowResordList", recordService.GetAllRecords(Convert.ToInt32(Session["idGuest"])).Select(rec => rec.ToMVCRecord()));

          
        }

        public ActionResult ShowInfoList(PersonViewModel model)
        {
            if (model == null)
            {
                return PartialView("_ShowInfoList", service.GetById(Convert.ToInt32(Session["idGuest"])).ToPLUser());

            }
            return PartialView("_ShowInfoList", model);
        }

        public ActionResult Subscribe()
        {
          
            service.ToSubscribe(Convert.ToInt32(Session["id"]), Convert.ToInt32(Session["idGuest"]));
            ViewBag.Status = true;
            return View("Index", service.GetById(Convert.ToInt32(Session["idGuest"])).ToPLUser());
            
           
        }

        public ActionResult Unsubscribe()
        {

            service.Unsubscribe(Convert.ToInt32(Session["id"]), Convert.ToInt32(Session["idGuest"]));
            ViewBag.Status = false;
            return View("Index", service.GetById(Convert.ToInt32(Session["idGuest"])).ToPLUser());


        }
	}
}