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
    public class HomeController : Controller
    {
        ImageFileManager imm = new ImageFileManager(new EFImageFileDAL());
        HeadingManager hem = new HeadingManager(new EFHeadingDAL());
        ContentManager com = new ContentManager(new EFContentDAL());
        WriterManager wrm = new WriterManager(new EFWriterDAL());
        MessageManager mem = new MessageManager(new EFMessageDAL());

        /// <summary>
        /// Url'deki ilk link
        /// </summary>
        /// <returns></returns>
        public ActionResult HomePage()
        {
            var imageValues = imm.ImageFileGetList();
            var headingValues = hem.HeadingGetList();
            var contentValues = com.ContentGetList("");
            var writerValues = wrm.WriterGetList();
            var messageValues = mem.MessageGetList();

            ViewBag.headingValues = (headingValues).Count;
            ViewBag.contentValues = (contentValues).Count;
            ViewBag.writerValues = (writerValues).Count;
            ViewBag.messageValues = (messageValues).Count;

            return View(imageValues);
        }
    }
}