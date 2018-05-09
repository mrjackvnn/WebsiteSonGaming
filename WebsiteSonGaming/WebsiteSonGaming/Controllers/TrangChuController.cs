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
        SonGamingDataContext db = new SonGamingDataContext();
        // GET: TrangChu
        public ActionResult Index()
        {
            return View(db.SANPHAMs.OrderBy(n=>n.giaban).Take(6).ToList());
        }

        public ActionResult ChiTiet(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(db.SANPHAMs.SingleOrDefault(n=>n.masanpham == id));
        }

        public ActionResult LoaiSanPham(int id)
        {
            return View(db.SANPHAMs.Where(n=>n.maloai == id).ToList());
        }
        public ActionResult LoaiSanPhamPartial()
        {
            return PartialView(db.LOAISANPHAMs.ToList());
        }
        public ActionResult NhaSanXuat(int id)
        {
            return View(db.SANPHAMs.Where(n=>n.mansx==id).ToList());
        }
        public ActionResult NhaSanXuatPartial()
        {
            return PartialView(db.NHASANXUATs.ToList());
        }
        public ActionResult TimKiemPartial()
        {
            return PartialView();
        }
    }
}