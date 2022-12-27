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
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDAL());
        AdminManager adm = new AdminManager(new EFAdminDAL());

        /// <summary>
        /// Tüm içerikleri getirir
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public ActionResult Index(string p = "")
        {
            var contentValues = cm.ContentGetList(p);
            return View(contentValues);
        }

        /// <summary>
        /// Başlığa göre içerikleri getirme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ContentsByHeading(int id)
        {
            var contentValues = cm.ContentGetListByHeading(id);
            return View(contentValues);
        }

        /// <summary>
        /// İçerik ekleme sayfası
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ContentAdd(int id)
        {
            ViewBag.d = id;
            return View();
        }

        /// <summary>
        /// İçerik ekleme işlemleri
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ContentAdd(Content p)
        {
            string mail = (string)Session["AdminUserName"];
            var adminValue = adm.AdminGetByMail(mail);

            p.WriterID = adminValue.AdminID;
            p.ContentCreatedDate = DateTime.Now;
            p.ContentCreatedID = adminValue.AdminID;
            p.ContentisActive = true;

            cm.ContentAdd(p);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// İçerik Güncelleme Sayfası
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ContentUpdate(int id)
        {
            var contentValue = cm.ContentGetById(id);
            return View(contentValue);
        }

        /// <summary>
        /// İçerik Güncelleme İşlemleri
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ContentUpdate(Content p)
        {
            string mail = (string)Session["AdminUserName"];
            var adminValue = adm.AdminGetByMail(mail);

            p.ContentUpdatedDate = DateTime.Now;
            p.ContentUpdatedID = adminValue.AdminID;
            p.ContentisActive = true;

            cm.ContentUpdate(p);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// İçerik Silme İşlemleri
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ContentDelete(int id)
        {
            var contentValue = cm.ContentGetById(id);
            string mail = (string)Session["AdminUserName"];
            var adminValue = adm.AdminGetByMail(mail);

            contentValue.ContentUpdatedDate = DateTime.Now;
            contentValue.ContentUpdatedID = adminValue.AdminID;
            contentValue.ContentisActive = false;

            cm.ContentUpdate(contentValue);
            return RedirectToAction("Index");
        }
    }
}