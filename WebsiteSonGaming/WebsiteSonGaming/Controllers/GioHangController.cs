using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteSonGaming.Models;

namespace WebsiteSonGaming.Controllers
{
    public class GioHangController : Controller
    {
        SonGamingEntities db = new SonGamingEntities();
        public List<GioHang> Laygiohang()
        {
            List<GioHang> lstGiohang = Session["GioHang"] as List<GioHang>;
            if (lstGiohang == null)
            {
                //Neu gio hang chua ton tai thi khoi tao listGiohang
                lstGiohang = new List<GioHang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }

        //Them hang vao gio
        public ActionResult ThemGiohang(int imasanpham, string strURL)
        {
            //Lay ra Session gio hang
            List<GioHang> lstGiohang = Laygiohang();
            //Kiem tra sách này tồn tại trong Session["Giohang"] chưa?
            GioHang sanpham = lstGiohang.Find(n => n.imasanpham == imasanpham);
            if (sanpham == null)
            {
                sanpham = new GioHang(imasanpham);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.isoluong++;
                return Redirect(strURL);
            }
        }

        //Xay dung trang Gio hang
        public ActionResult GioHang()
        {
            List<GioHang> lstGiohang = Laygiohang();
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "TrangChu");
            }
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return View(lstGiohang);
        }

        //Tong so luong
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGiohang = Session["GioHang"] as List<GioHang>;
            if (lstGiohang != null)
            {
                iTongSoLuong = lstGiohang.Sum(n => n.isoluong);
            }
            return iTongSoLuong;
        }
        //Tinh tong tien
        private double TongTien()
        {
            double iTongTien = 0;
            List<GioHang> lstGiohang = Session["GioHang"] as List<GioHang>;
            if (lstGiohang != null)
            {
                iTongTien = lstGiohang.Sum(n => n.dthanhtien);
            }
            return iTongTien;
        }

        //Tao Partial view de hien thi thong tin gio hang
        public ActionResult GioHangPartial()
        {
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return PartialView();
        }

        //Cap nhat Giỏ hàng
        public ActionResult CapNhatGioHang(int imasanpham, FormCollection f)
        {

            //Lay gio hang tu Session
            List<GioHang> lstGiohang = Laygiohang();
            //Kiem tra sp da co trong Session["Giohang"]
            GioHang sanpham = lstGiohang.SingleOrDefault(n => n.imasanpham == imasanpham);
            //Neu ton tai thi cho sua Soluong
            if (sanpham != null)
            {
                sanpham.isoluong = int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("GioHang");
        }

        //Xoa Giohang
        public ActionResult XoaGioHang(int imasanpham)
        {
            //Lay gio hang tu Session
            List<GioHang> lstGioHang = Laygiohang();
            //Kiem tra sach da co trong Session["Giohang"]
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.imasanpham == imasanpham);
            //Neu ton tai thi cho sua Soluong
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.imasanpham == imasanpham);
                return RedirectToAction("GioHang");

            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "TrangChu");
            }
            return RedirectToAction("GioHang");
        }
        //Xoa tat ca thong tin trong Gio hang
        public ActionResult XoaTatCaGiohang()
        {
            //Lay gio hang tu Session
            List<GioHang> lstGiohang = Laygiohang();
            lstGiohang.Clear();
            return RedirectToAction("Index", "TrangChu");
        }

        //Hien thi View mua hang de cap nhat cac thong tin cho Don hang
        [HttpGet]
        public ActionResult MuaHang()
        {
            //Kiem tra dang nhap
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "TrangChu");
            }

            //Lay gio hang tu Session
            List<GioHang> lstGiohang = Laygiohang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();

            return View(lstGiohang);
        }
        //Xay dung chuc nang mua hang
        [HttpPost]
        public ActionResult MuaHang(FormCollection f)
        {
            //Them Don hang
            HOADON hd = new HOADON();
            KHACHHANG kh = (KHACHHANG)Session["TaiKhoan"];
            List<GioHang> gh = Laygiohang();
            hd.makh = kh.makh;
            hd.ngaydat = DateTime.Now;
            db.HOADON.Add(hd);
            db.SaveChanges();
            //Them chi tiet don hang            
            foreach (var item in gh)
            {
                CHITIETHOADON cthd = new CHITIETHOADON();
                cthd.mahoadon = hd.mahoadon;
                cthd.masanpham = item.imasanpham;
                cthd.soluong = item.isoluong;
                cthd.dongia = item.dgiaban;
                db.CHITIETHOADON.Add(cthd);
            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("XacNhanMuaHang", "GioHang");
        }
        public ActionResult XacNhanMuaHang()
        {
            return View();
        }
    }
}