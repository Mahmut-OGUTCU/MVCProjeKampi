using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDAL());
        MessageValidator mv = new MessageValidator();
        AdminManager adm = new AdminManager(new EFAdminDAL());

        /// <summary>
        /// Giriş Yapan Admin'e Yazılan Yazılar Sayfası
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Inbox()
        {
            string mail = (string)Session["AdminUserName"];

            var messageValues = mm.MessageGetListInbox(mail);
            return View(messageValues);
        }

        /// <summary>
        /// Giriş Yapan Admin'in Yazdığı Yazılar Sayfası
        /// </summary>
        /// <returns></returns>
        public ActionResult SendBox()
        {
            string mail = (string)Session["AdminUserName"];

            var messageValues = mm.MessageGetListSendbox(mail);
            return View(messageValues);
        }

        /// <summary>
        /// Mesaj Yazma Sayfası
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MessageAdd()
        {
            return View();
        }

        /// <summary>
        /// Mesaj Yazma İşlemleri
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MessageAdd(Message p)
        {
            ValidationResult result = mv.Validate(p);

            if (result.IsValid)
            {
                string mail = (string)Session["AdminUserName"];
                var adminValue = adm.AdminGetByMail(mail);

                p.SenderMail = mail;
                p.MessageCreatedDate = DateTime.Now;
                p.MessageCreatedID = adminValue.AdminID;
                p.MessageisActive = true;
                p.MessageisRead = false;

                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
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
        /// Giriş Yapan Admin'e Yazılan Yazıların Detayları
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetInboxMessageDetails(int id)
        {
            var messageValue = mm.MessageGetByID(id);

            string mail = (string)Session["AdminUserName"];
            var adminValue = adm.AdminGetByMail(mail);

            messageValue.MessageisRead = true;
            messageValue.MessageUpdatedID = adminValue.AdminID;
            messageValue.MessageUpdatedDate = DateTime.Now;

            mm.MessageUpdate(messageValue);
            return View(messageValue);
        }

        /// <summary>
        /// Giriş Yapan Admin'in Yazdığı Yazıların Detayları
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messageValue = mm.MessageGetByID(id);
            return View(messageValue);
        }
    }
}