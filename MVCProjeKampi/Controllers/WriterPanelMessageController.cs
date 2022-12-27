using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDAL());
        WriterManager wm = new WriterManager(new EFWriterDAL());
        MessageValidator mv = new MessageValidator();

        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageValues = mm.MessageGetListInbox(mail);
            return View(messageValues);
        }

        public ActionResult SendBox()
        {
            string mail = (string)Session["WriterMail"];
            var messageValues = mm.MessageGetListSendbox(mail);
            return View(messageValues);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var messageValue = mm.MessageGetByID(id);
            string mail = (string)Session["WriterMail"];
            var writerValue = wm.WriterGetByMail(mail);

            messageValue.MessageisRead = true;
            messageValue.MessageUpdatedID = writerValue.WriterID;
            messageValue.MessageUpdatedDate = DateTime.Now;

            mm.MessageUpdate(messageValue);
            return View(messageValue);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messageValue = mm.MessageGetByID(id);
            return View(messageValue);
        }

        [HttpGet]
        public ActionResult MessageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MessageAdd(Message p)
        {
            ValidationResult result = mv.Validate(p);

            if (result.IsValid)
            {
                var mail = (string)Session["WriterMail"];
                var writerValue = wm.WriterGetByMail(mail);

                p.SenderMail = mail;
                p.MessageCreatedDate = DateTime.Now;
                p.MessageCreatedID = writerValue.WriterID;
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

        public PartialViewResult MessageListMenu()
        {
            string mail = (string)Session["WriterMail"];

            var inboxValues = mm.MessageGetListInbox(mail);

            var readInboxValues = from x in inboxValues where x.MessageisRead == false select x;

            ViewBag.readInboxValues = readInboxValues.Count();

            return PartialView();
        }
    }
}