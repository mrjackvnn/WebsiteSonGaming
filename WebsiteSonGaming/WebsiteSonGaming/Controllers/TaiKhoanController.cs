using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteSonGaming.Models;


namespace WebsiteSonGaming.Controllers
{
    public class TaiKhoanController : Controller
    {
        SonGamingEntities db = new SonGamingEntities();
        [HttpGet]
        // GET: TaiKhoan
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KHACHHANG kh)
        {
            db.KHACHHANG.Add(kh);
            db.SaveChanges();
            return View();
        }
    }
}