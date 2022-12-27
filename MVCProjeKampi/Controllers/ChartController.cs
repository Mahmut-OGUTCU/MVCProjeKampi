using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MVCProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        HeadingManager hem = new HeadingManager(new EFHeadingDAL());
        ContentManager com = new ContentManager(new EFContentDAL());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult CategoryChart1()
        {
            var headingValues = hem.HeadingGetList();

            var headingPerCategory = from heading in headingValues
                                     orderby heading.Category.CategoryName
                                     group heading by heading.Category.CategoryName into c
                                     select new { Name = c.Key, CategoryCount = c.Count() };

            return Json(headingPerCategory, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CategoryChart2()
        {
            var contentValues = com.ContentGetList("");

            var contentPerHeading = from content in contentValues
                                    orderby content.Heading.HeadingName
                                    group content by content.Heading.HeadingName into c
                                    select new { Name = c.Key, ContentCount = c.Count() };

            return Json(contentPerHeading, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CategoryChart3()
        {
            var contentValues = com.ContentGetList("");

            var contentPerWriter = from content in contentValues
                                   orderby content.Writer.WriterName
                                   group content by content.Writer.WriterName into c
                                   select new { Name = c.Key, ContentCount = c.Count() };

            return Json(contentPerWriter, JsonRequestBehavior.AllowGet);
        }
    }
}