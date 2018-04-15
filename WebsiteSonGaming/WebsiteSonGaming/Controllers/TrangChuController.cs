using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteSonGaming.Models;

namespace WebsiteSonGaming.Controllers
{
    public class TrangChuController : Controller
    {
        SonGamingEntities db = new SonGamingEntities();
        // GET: TrangChu
        public ActionResult Index()
        {
            return View(db.SANPHAM.OrderBy(n=>n.giaban).Take(6).ToList());
        }

        public ActionResult ChiTiet()
        {
            return View();
        }

        public ActionResult LoaiSanPham(int id)
        {
            return View(db.SANPHAM.Where(n=>n.maloai == id).ToList());
        }
        public ActionResult LoaiSanPhamPartial()
        {
            return PartialView(db.LOAISANPHAM.ToList());
        }
        public ActionResult NhaSanXuat(int id)
        {
            return View(db.SANPHAM.Where(n=>n.mansx==id).ToList());
        }
        public ActionResult NhaSanXuatPartial()
        {
            return PartialView(db.NHASANXUAT.ToList());
        }
    }
}