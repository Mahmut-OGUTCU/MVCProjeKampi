using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDAL());
        ContentManager cm = new ContentManager(new EFContentDAL());

        public PartialViewResult Index(int id = 0)
        {
            var contentValues = cm.ContentGetListByHeading(id);
            return PartialView(contentValues);
        }

        public ActionResult Headings()
        {
            var headingValues = hm.HeadingGetList();
            return View(headingValues);
        }
    }
}