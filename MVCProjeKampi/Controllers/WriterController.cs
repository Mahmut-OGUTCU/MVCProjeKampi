using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace MVCProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterDAL());
        AdminManager adm = new AdminManager(new EFAdminDAL());
        WriterValidator writerValidator = new WriterValidator();

        /// <summary>
        /// Yazarları Listeleme Sayfası
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var writerValues = wm.WriterGetList();
            return View(writerValues);
        }

        /// <summary>
        /// Yazar Ekleme Sayfası
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }

        /// <summary>
        /// Yazar Ekleme İşlemleri
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult WriterAdd(Writer p)
        {
            ValidationResult result = writerValidator.Validate(p);
            if (result.IsValid)
            {
                string mail = (string)Session["AdminUserName"];
                var adminValue = adm.AdminGetByMail(mail);

                p.WriterCreatedDate = DateTime.Now;
                p.WriterisActive = true;
                p.WriterCreatedID = adminValue.AdminID;

                if (Request.Files.Count > 0)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string type = Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/AdminLTE-3.0.4/writer-image/" + fileName + type;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    p.WriterImage = "/AdminLTE-3.0.4/writer-image/" + fileName + type;
                }

                if (p.WriterImage == null)
                {
                    p.WriterImage = "https://c7.alamy.com/comp/MFWFPP/nobody-knows-retro-clipart-illustration-MFWFPP.jpg";
                }

                wm.WriterAdd(p);
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

        /// <summary>
        /// Yazar Güncelleme Sayfası
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult WriterUpdate(int id)
        {
            var writerValue = wm.WriterGetById(id);
            return View(writerValue);
        }

        /// <summary>
        /// Yazar Güncelleme İşlemleri
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult WriterUpdate(Writer p)
        {
            ValidationResult result = writerValidator.Validate(p);
            if (result.IsValid)
            {
                string mail = (string)Session["AdminUserName"];
                var adminValue = adm.AdminGetByMail(mail);

                p.WriterUpdatedDate = DateTime.Now;
                p.WriterUpdatedID = adminValue.AdminID;
                p.WriterisActive = true;

                if (Request.Files.Count > 0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/AdminLTE-3.0.4/writer-image/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.WriterImage = "/AdminLTE-3.0.4/writer-image/" + dosyaadi + uzanti;
                }

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

        /// <summary>
        /// Yazar Silme İşlemleri
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult WriterDelete(int id)
        {
            var writerValue = wm.WriterGetById(id);

            string mail = (string)Session["AdminUserName"];
            var adminValue = adm.AdminGetByMail(mail);

            writerValue.WriterUpdatedDate = DateTime.Now;
            writerValue.WriterUpdatedID = adminValue.AdminID;
            writerValue.WriterisActive = false;

            if (writerValue.WriterImage == null)
            {
                writerValue.WriterImage = "https://c7.alamy.com/comp/MFWFPP/nobody-knows-retro-clipart-illustration-MFWFPP.jpg";
            }

            wm.WriterUpdate(writerValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult WriterRegister(string str = "str")
        {
            ViewBag.str = str;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult WriterRegister(Writer p)
        {
            ValidationResult result = writerValidator.Validate(p);
            if (result.IsValid)
            {
                var writerValues = wm.WriterGetList();

                string mail = (string)Session["AdminUserName"];
                var adminValue = adm.AdminGetByMail(mail);

                p.WriterCreatedDate = DateTime.Now;
                p.WriterisActive = true;
                p.WriterCreatedID = 0;

                if (p.WriterImage == null)
                {
                    p.WriterImage = "https://c7.alamy.com/comp/MFWFPP/nobody-knows-retro-clipart-illustration-MFWFPP.jpg";
                }


                //TODO: düzelt
                var res = writerValues.Any(m => m.WriterMail == p.WriterMail);

                if (res)
                {
                    return View();
                }



                wm.WriterAdd(p);
                return RedirectToAction("WriterLogin", "Login");
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
    }
}