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
        private static PersonViewModel guestModel { get; set; }


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

                guestModel = service.GetById(id).ToPLUser();
                AccountController.personModel.ListFriendId = service.GetSubscribe(AccountController.personModel.Id);
                foreach (var sign in AccountController.personModel.ListFriendId)
                {
                    if (sign == id)
                    {
                        guestModel.IdRole = 4;
                    }
                }
                return View(guestModel);
            }
            return View(guestModel);
        }

        public ActionResult ShowRecordsListNull(int id = 0)
        {
            if (id == 0)
            {
                return PartialView("_ShowResordList", recordService.GetAllRecords(guestModel.Id).Select(rec => rec.ToMVCRecord()));

            }
            return PartialView("_ShowResordList", recordService.GetAllRecords(id).Select(rec => rec.ToMVCRecord()));
        }

        public ActionResult ShowInfoList(PersonViewModel model)
        {
            if (model == null)
            {
                return PartialView("_ShowInfoList", guestModel);

            }
            return PartialView("_ShowInfoList", model);
        }

        public ActionResult Subscribe(int id =0)
        {
                AccountController.personModel.ListFriendId=service.ToSubscribe(AccountController.personModel.Id, guestModel.Id);
                guestModel.IdRole = 4;
                return View("Index", guestModel);
            
           
        }
	}
}