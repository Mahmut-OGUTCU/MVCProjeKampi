using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDAL());
        WriterManager wrm = new WriterManager(new EFWriterDAL());

        public ActionResult MyContent()
        {
            string mail = (string)Session["WriterMail"];
            var writerValue = wrm.WriterGetByMail(mail);
            var contentValues = cm.ContentGetListByWriter(writerValue.WriterID);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult ContentAdd(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult ContentAdd(Content p)
        {
            string mail = (string)Session["WriterMail"];
            var writerValue = wrm.WriterGetByMail(mail);

            p.WriterID = writerValue.WriterID;
            p.ContentCreatedDate = DateTime.Now;
            p.ContentCreatedID = writerValue.WriterID;
            p.ContentisActive = true;

            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }

        [HttpGet]
        public ActionResult ContentUpdate(int id)
        {
            var contentValue = cm.ContentGetById(id);
            return View(contentValue);
        }

        [HttpPost]
        public ActionResult ContentUpdate(Content p)
        {
            string mail = (string)Session["WriterMail"];
            var writerValue = wrm.WriterGetByMail(mail);

            p.ContentUpdatedDate = DateTime.Now;
            p.ContentUpdatedID = writerValue.WriterID;
            p.ContentisActive = true;

            cm.ContentUpdate(p);
            return RedirectToAction("MyContent");
        }

        public ActionResult ContentDelete(int id)
        {
            var contentValue = cm.ContentGetById(id);
            string mail = (string)Session["WriterMail"];
            var writerValue = wrm.WriterGetByMail(mail);

            contentValue.ContentUpdatedDate = DateTime.Now;
            contentValue.ContentUpdatedID = writerValue.WriterID;
            contentValue.ContentisActive = false;

            cm.ContentUpdate(contentValue);
            return RedirectToAction("MyContent");
        }
    }
}