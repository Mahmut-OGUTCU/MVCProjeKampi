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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());
        AdminManager adm = new AdminManager(new EFAdminDAL());

        /// <summary>
        /// Kategori Listesi Sayfası
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var categoryValues = cm.CategoryGetList();
            return View(categoryValues);
        }

        /// <summary>
        /// Kategori Ekleme Sayfası
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        /// <summary>
        /// Kategori Ekleme İşlemleri
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CategoryAdd(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                string adminMail = (string)Session["AdminUserName"];
                var adminValues = adm.AdminGetByMail(adminMail);

                p.CategoryCreatedDate = DateTime.Now;
                p.CategoryCreatedID = adminValues.AdminID;
                p.CategoryisActive = true;

                cm.CategoryAdd(p);
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
        /// Kategori Silme İşlemleri
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CategoryDelete(int id)
        {
            var categoryValue = cm.CategoryGetByID(id);

            string adminMail = (string)Session["AdminUserName"];
            var adminValues = adm.AdminGetByMail(adminMail);

            categoryValue.CategoryUpdatedDate = DateTime.Now;
            categoryValue.CategoryUpdatedID = adminValues.AdminID;
            categoryValue.CategoryisActive = false;

            cm.CategoryUpdate(categoryValue);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Kategori Güncelleme Sayfası
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            var categoryValue = cm.CategoryGetByID(id);
            return View(categoryValue);
        }

        /// <summary>
        /// Kategori Ekleme İşlemleri
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CategoryUpdate(Category p)
        {
            string adminMail = (string)Session["AdminUserName"];
            var adminValues = adm.AdminGetByMail(adminMail);

            p.CategoryUpdatedDate = DateTime.Now;
            p.CategoryUpdatedID = adminValues.AdminID;
            p.CategoryisActive = true;

            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}