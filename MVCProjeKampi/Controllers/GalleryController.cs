using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager im = new ImageFileManager(new EFImageFileDAL());

        public ActionResult Index()
        {
            var galaryValues = im.ImageFileGetList();
            return View(galaryValues);
        }

        [HttpGet]
        public ActionResult GalleryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GalleryAdd(ImageFile p)
        {
            im.ImageFileAdd(p);
            return RedirectToAction("Index");
        }
    }
}