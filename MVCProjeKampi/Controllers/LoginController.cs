using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace MVCProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager wlm = new WriterLoginManager(new EFWriterDAL());
        AdminManager adm = new AdminManager(new EFAdminDAL());

        /// <summary>
        /// Admin Giriş Sayfası
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Admin Giriş İşlemi
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            p.AdminPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(p.AdminPassword)));

            var adminuserinfo = adm.AdminGet(p.AdminUserName, p.AdminPassword);

            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Yazar Giriş Sayfası
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        /// <summary>
        /// Yazar Giriş İşlemi
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult WriterLogin(Writer p)
        {
            var writeruserinfo = wlm.GetWriter(p.WriterMail, p.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        /// <summary>
        /// Yazar ve Admin Çıkış İşlemi
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}