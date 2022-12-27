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
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDAL());
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());
        WriterManager wm = new WriterManager(new EFWriterDAL());
        AdminManager adm = new AdminManager(new EFAdminDAL());
        WriterManager wrm = new WriterManager(new EFWriterDAL());

        /// <summary>
        /// Başlık Listesi Sayfası
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var headingValues = hm.HeadingGetList();
            return View(headingValues);
        }

        /// <summary>
        /// Başlık Ekleme Sayfası
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult HeadingAdd()
        {
            List<SelectListItem> valueCategory = (from x in cm.CategoryGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> valueWriter = (from x in wm.WriterGetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }

        /// <summary>
        /// Başlık Ekleme İşlemleri
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult HeadingAdd(Heading p)
        {
            string mail = (string)Session["AdminUserName"];
            var adminValue = adm.AdminGetByMail(mail);

            p.HeadingCreatedDate = DateTime.Now;
            p.HeadingCreatedID = adminValue.AdminID;
            p.WriterID = adminValue.AdminID;
            p.HeadingisActive = true;

            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Başlık Güncelleme Sayfası
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Başlık Güncelleme İşlemleri
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult HeadingUpdate(Heading p)
        {
            string mail = (string)Session["AdminUserName"];
            var adminValue = adm.AdminGetByMail(mail);

            p.HeadingUpdatedDate = DateTime.Now;
            p.HeadingUpdatedID = adminValue.AdminID;
            p.HeadingisActive = true;

            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Başlık Silme İşlemleri
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult HeadingDelete(int id)
        {
            var headingValue = hm.HeadingGetById(id);

            string mail = (string)Session["AdminUserName"];
            var adminValue = adm.AdminGetByMail(mail);

            headingValue.HeadingUpdatedDate = DateTime.Now;
            headingValue.HeadingUpdatedID = adminValue.AdminID;
            headingValue.HeadingisActive = false;

            hm.HeadingUpdate(headingValue);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Gelen kategori id'sine göre başlık listeleme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult HeadingByCategory(int id)
        {
            var headingValues = hm.HeadingGetList();
            headingValues = (from x in headingValues where x.CategoryID == id select x).ToList();

            return View(headingValues);
        }

        /// <summary>
        /// Gelen yazar id'sine göre başlık listeleme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult HeadingByWriter(int id)
        {
            var headingValues = hm.HeadingGetList();
            headingValues = (from x in headingValues where x.WriterID == id select x).ToList();

            return View(headingValues);
        }
    }
}