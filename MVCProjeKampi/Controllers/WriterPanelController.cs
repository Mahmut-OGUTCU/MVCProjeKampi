using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MVCProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDAL());
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());
        WriterManager wm = new WriterManager(new EFWriterDAL());

        [HttpGet]
        public ActionResult WriterProfile()
        {
            string mail = (string)Session["WriterMail"];
            var writerValue = wm.WriterGetByMail(mail);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(p);
            if (result.IsValid)
            {
                string mail = (string)Session["WriterMail"];
                var writerValue = wm.WriterGetByMail(mail);

                p.WriterUpdatedDate = DateTime.Now;
                p.WriterUpdatedID = writerValue.WriterID;
                p.WriterisActive = true;

                if (p.WriterImage == null)
                {
                    p.WriterImage = "https://c7.alamy.com/comp/MFWFPP/nobody-knows-retro-clipart-illustration-MFWFPP.jpg";
                }

                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult MyHeading()
        {
            string mail = (string)Session["WriterMail"];
            var writerValue = wm.WriterGetByMail(mail);
            var headingValues = hm.HeadingGetListByWriter(writerValue.WriterID);
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult HeadingAdd()
        {
            List<SelectListItem> valueCategory = (from x in cm.CategoryGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;

            return View();
        }

        [HttpPost]
        public ActionResult HeadingAdd(Heading p)
        {
            string mail = (string)Session["WriterMail"];
            var writerValue = wm.WriterGetByMail(mail);

            p.HeadingCreatedDate = DateTime.Now;
            p.HeadingCreatedID = writerValue.WriterID;
            p.HeadingisActive = true;
            p.WriterID = writerValue.WriterID;

            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult HeadingUpdate(int id)
        {
            var headingValue = hm.HeadingGetById(id);

            List<SelectListItem> valueCategory = (from x in cm.CategoryGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;

            return View(headingValue);
        }

        [HttpPost]
        public ActionResult HeadingUpdate(Heading p)
        {
            string mail = (string)Session["WriterMail"];
            var writerValue = wm.WriterGetByMail(mail);

            p.HeadingisActive = true;
            p.HeadingUpdatedDate = DateTime.Now;
            p.HeadingUpdatedID = writerValue.WriterID;

            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult HeadingDelete(int id)
        {
            var headingValue = hm.HeadingGetById(id);
            string mail = (string)Session["WriterMail"];
            var writerValue = wm.WriterGetByMail(mail);

            headingValue.HeadingisActive = false;
            headingValue.HeadingUpdatedDate = DateTime.Now;
            headingValue.HeadingUpdatedID = writerValue.WriterID;

            hm.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int page = 1)
        {
            var headingValues = hm.HeadingGetList().ToPagedList(page, 4);
            return View(headingValues);
        }
    }
}