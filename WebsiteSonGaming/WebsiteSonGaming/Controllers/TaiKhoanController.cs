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
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KHACHHANG kh)
        {
            if(ModelState.IsValid)
            {
                db.KHACHHANG.Add(kh);
                db.SaveChanges();
                return RedirectToAction("DangKyThanhCong");
            }
            return View(kh);
            
        }
        public ActionResult DangKyThanhCong()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string strTaiKhoan = f.Get("txtTenDangNhap").ToString();
            string strMatKhau = f.Get("txtMatKhau").ToString();
            KHACHHANG kh = db.KHACHHANG.SingleOrDefault(n => n.taikhoan == strTaiKhoan && n.matkhau == strMatKhau);
            if(kh != null)
            {
                Session["TaiKhoan"] = kh;
                return RedirectToAction("DangNhapThanhCong");
            }
            if(strTaiKhoan==null)
            {
                ViewBag.LoiDangNhap = "Tên đăng nhập không được để trống";
            }
            if(strMatKhau==null)
            {
                ViewBag.LoiMatKhau = "Mật khẩu không được để trống";
            }
            ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
            return View();
        }
        public ActionResult DangNhapThanhCong()
        {
            return View();
        }

        public ActionResult LoginPartial()
        {
            return PartialView();
        }

        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "TrangChu");
        }
    }
}