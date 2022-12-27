using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDAL());
        MessageManager mes = new MessageManager(new EFMessageDAL());
        AdminManager adm = new AdminManager(new EFAdminDAL());
        ContactValidator cv = new ContactValidator();

        /// <summary>
        /// AnaSayfadan Gelen Mailler için olan sayfa
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var contactValues = cm.ContactGetList();
            return View(contactValues);
        }

        /// <summary>
        /// AnaSayfadan Gelen Maillerin detaylarını görüntülemek için
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetContactDetails(int id)
        {
            var contactValue = cm.ContactGetByID(id);
            string mail = (string)Session["AdminUserName"];
            var adminValue = adm.AdminGetByMail(mail);

            contactValue.ContactisRead = true;
            contactValue.ContactUpdatedID = adminValue.AdminID;
            contactValue.ContactUpdatedDate = DateTime.Now;

            cm.ContactUpdate(contactValue);

            return View(contactValue);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ContactAdd(Contact p)
        {
            p.ContactisActive = true;
            p.ContactCreatedDate = DateTime.Now;
            cm.ContactAdd(p);
            return RedirectToAction("HomePage", "Home");
        }

        /// <summary>
        /// Admin paneli için mesajlardaki sol panel
        /// </summary>
        /// <returns></returns>
        public PartialViewResult ContactPartial()
        {
            string mail = (string)Session["AdminUserName"];

            var inboxValues = mes.MessageGetListInbox(mail);
            var contactValues = cm.ContactGetList();

            var readInboxValues = from x in inboxValues where x.MessageisRead == false select x;
            var readContactValues = from x in contactValues where x.ContactisRead == false select x;

            ViewBag.readInboxValues = readInboxValues.Count();
            ViewBag.readContactValues = readContactValues.Count();

            return PartialView();
        }
    }
}