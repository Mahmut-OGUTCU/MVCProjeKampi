using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EFAdminDAL());

        SHA1 sha = new SHA1CryptoServiceProvider();

        /// <summary>
        /// Admin'lerin listelendiği sayfa
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var adminValues = adm.AdminGetList();
            return View(adminValues);
        }

        /// <summary>
        /// Admin Ekleme Sayfası
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }

        /// <summary>
        /// Admin Ekleme İşlemi
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AdminAdd(Admin p)
        {
            string adminMail = (string)Session["AdminUserName"];
            var adminValues = adm.AdminGetByMail(adminMail);

            p.AdminPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(p.AdminPassword)));

            p.AdminCreatedDate = DateTime.Now;
            p.AdminCreatedID = adminValues.AdminID;
            p.AdminisActive = true;

            adm.AdminAdd(p);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Admin Güncelleme Sayfası
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminUpdate(int id)
        {
            var adminValue = adm.AdminGetByID(id);
            return View(adminValue);
        }

        /// <summary>
        /// Admin Güncelleme İşlemi
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AdminUpdate(Admin p)
        {
            string adminMail = (string)Session["AdminUserName"];
            var adminValues = adm.AdminGetByMail(adminMail);

            p.AdminUpdatedDate = DateTime.Now;
            p.AdminUpdatedID = adminValues.AdminID;
            p.AdminisActive = true;

            //TODO: şifre işlemleri ile ilgili bir düzenleme olması gerekiyor.

            adm.AdminUpdate(p);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Admin Silme İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AdminDelete(int id)
        {
            string adminMail = (string)Session["AdminUserName"];
            var adminValues = adm.AdminGetByMail(adminMail);

            var adminValue = adm.AdminGetByID(id);

            adminValue.AdminUpdatedDate = DateTime.Now;
            adminValue.AdminUpdatedID = adminValues.AdminID;
            adminValue.AdminisActive = false;

            adm.AdminUpdate(adminValue);
            return RedirectToAction("Index");
        }
    }
}