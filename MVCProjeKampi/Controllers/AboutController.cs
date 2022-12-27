using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EFAboutDAL());
        public ActionResult Index()
        {
            var aboutValues = abm.AboutGetList();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AboutAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AboutAdd(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}