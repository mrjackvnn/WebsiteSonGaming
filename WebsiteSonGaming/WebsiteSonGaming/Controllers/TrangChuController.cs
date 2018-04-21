using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult ChiTiet(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sp = db.SANPHAM.Find(id);
            if(sp==null)
            {
                return HttpNotFound();
            }
            return View(db.SANPHAM.SingleOrDefault(n=>n.masanpham == id));
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
        public ActionResult TimKiemPartial()
        {
            return PartialView();
        }
    }
}