using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteSonGaming.Models;

namespace WebsiteSonGaming.Controllers
{
    public class TimKiemController : Controller
    {
        SonGamingDataContext db = new SonGamingDataContext();
        // GET: TimKiem
        [HttpGet]
        public ActionResult KetQuaTimKiem(FormCollection f)
        {
            string strTuKhoa = f.Get("txtTuKhoa").ToString();
            List<SANPHAM> lstKQTK = db.SANPHAMs.Where(n => n.tensanpham.Contains(strTuKhoa)).ToList();
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy kết quả nào";
                return View(lstKQTK.OrderBy(n => n.tensanpham));
            }
            return View(lstKQTK.OrderBy(n => n.tensanpham));
        }
        [HttpPost]
        public ActionResult KetQuaTimKiem(string strTuKhoa)
        {
            List<SANPHAM> lstKQTK = db.SANPHAMs.Where(n => n.tensanpham.Contains(strTuKhoa)).ToList();
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy kết quả nào";
                return View(lstKQTK.OrderBy(n => n.tensanpham));
            }
            return View(lstKQTK.OrderBy(n => n.tensanpham));
        }
    }
}