using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteSonGaming.Models;
using System.IO;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;

namespace WebsiteSonGaming.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        SonGamingDataContext db = new SonGamingDataContext();
        // GET: Admin
        #region Trang Chu Admin
       public ActionResult Index()
        {
            return View();
        }
        #endregion

        public ActionResult ThemThanhCong()
        {
            return View();
        }

        public ActionResult XoaThanhCong()
        {
            return View();
        }

        public ActionResult SuaThanhCong()
        {
            return View();
        }
        #region Quan Ly San Pham
        public ActionResult QuanLySanPham(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.SANPHAMs.OrderBy(n => n.masanpham).ToList().ToPagedList(pageNumber, pageSize));
        }

        #region Them Moi San Pham
        [HttpGet]
        public ActionResult ThemMoiSanPham()
        {
            //Dua du lieu vao dropdownList
            //Lay ds tu tabke chu de, sắp xep tang dan trheo ten chu de, chon lay gia tri Ma CD, hien thi thi Tenchude
            ViewBag.MaLoai = new SelectList(db.LOAISANPHAMs.ToList().OrderBy(n => n.tenloai), "maloai", "tenloai");
            ViewBag.MaNsx = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.tennsx), "mansx", "tennsx");
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiSanPham(SANPHAM sp, HttpPostedFileBase fileUpload)
        {
            //Dua du lieu vao dropdownload
            ViewBag.MaLoai = new SelectList(db.LOAISANPHAMs.ToList().OrderBy(n => n.tenloai), "maloai", "tenloai");
            ViewBag.MaNsx = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.tennsx), "mansx", "tennsx");
            //Kiem tra duong dan file
            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn hình sản phẩm";
            }
            //Them vao CSDL
            else
            {
                //Luu ten fie, luu y bo sung thu vien using System.IO;
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/Assets/Images/HinhSanPham"), fileName);
                //Kiem tra hình anh ton tai chua?
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    //Luu hinh anh vao duong dan
                    fileUpload.SaveAs(path);
                }
                sp.hinhsanpham = fileUpload.FileName;
                //Luu vao CSDL
                db.SANPHAMs.InsertOnSubmit(sp);
                db.SubmitChanges();
                return RedirectToAction("ThemThanhCong");
            }
            return View();
        }
        
        #endregion

        #region Chi Tiet San Pham
        public ActionResult ChiTietSanPham(int id)
        {
            //Lay ra doi tuong sach theo ma
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.masanpham == id);
            ViewBag.MaSanPham = sp.masanpham;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
        #endregion

        #region Xoa San Pham
        [HttpGet]
        public ActionResult XoaSanPham(int id)
        {
            //Lay ra doi tuong sach can xoa theo ma
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.masanpham == id);
            ViewBag.MaSanPham = sp.masanpham;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }

        [HttpPost, ActionName("XoaSanPham")]
        public ActionResult XacNhanXoa(int id)
        {
            //Lay ra doi tuong sach can xoa theo ma
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.masanpham == id);
            ViewBag.MaSanPham = sp.masanpham;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SANPHAMs.DeleteOnSubmit(sp);
            db.SubmitChanges();
            return RedirectToAction("XoaThanhCong");
        }
        #endregion

        #region Sua San Pham
        [HttpGet]
        public ActionResult SuaSanPham(int id)
        {
            //Lay ra doi tuong sach theo ma
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.masanpham == id);
            ViewBag.MaSanPham = sp.masanpham;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Dua du lieu vao dropdownList
            //Lay ds tu tabke chu de, sắp xep tang dan trheo ten chu de, chon lay gia tri Ma CD, hien thi thi Tenchude
            ViewBag.MaLoai = new SelectList(db.LOAISANPHAMs.ToList().OrderBy(n => n.tenloai), "maloai", "tenloai");
            ViewBag.MaNsx = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.tennsx), "mansx", "tennsx");
            return View(sp);
        }
        [HttpPost]
        public ActionResult SuaSanPham(int id, FormatException f)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.masanpham == id);
            //Dua du lieu vao dropdownload
            ViewBag.MaLoai = new SelectList(db.LOAISANPHAMs.ToList().OrderBy(n => n.tenloai), "maloai", "tenloai");
            ViewBag.MaNsx = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.tennsx), "mansx", "tennsx");
            //Luu vao CSDL   
            UpdateModel(sp);
            db.SubmitChanges();
            return RedirectToAction("QuanLySanPham");
        }
        #endregion
        #endregion

        #region Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            // Gán các giá trị người dùng nhập liệu cho các biến 
            var tendn = collection["username"];
            var matkhau = collection["password"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (ad)        

                ADMIN ad = db.ADMINs.SingleOrDefault(n => n.username == tendn && n.password == matkhau);
                if (ad != null)
                {
                    // ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("QuanLySanPham", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        #endregion

        #region Khach Hang

        public ActionResult KhachHang()
        {
            return View(db.KHACHHANGs.ToList());
        }

        public ActionResult ChiTietKhachHang(int id)
        {
            var kh = db.KHACHHANGs.First(n => n.makh == id);
            return View(kh);
        }

        [HttpGet]
        public ActionResult XoaKhachHang(int id)
        {
            var kh = db.KHACHHANGs.First(n => n.makh == id);
            return View(kh);
        }
        [HttpPost,ActionName("XoaKhachHang")]
        public ActionResult XacNhanXoaKhachHang(int id)
        {
            var kh = db.KHACHHANGs.First(n => n.makh == id);
            db.KHACHHANGs.DeleteOnSubmit(kh);
            db.SubmitChanges();
            return RedirectToAction("XoaThanhCong");
        }
       
        #endregion

        #region Quản Lý Đơn Hàng
        public ActionResult DonHang()
        {
            return View(db.DONHANGs.ToList());
        }
        public ActionResult ChiTietDonHang(int id)
        {
            var tt = db.HOADONs.First(n => n.mahoadon == id);
            ViewBag.TT = tt.tinhtrang;
            return View(db.CTDHs.Where(n=>n.mahoadon==id).ToList());
        }
        [HttpPost]
        public ActionResult CheckTinhTrang(int id)
        {
            var tt = db.HOADONs.First(n => n.mahoadon == id);
            tt.tinhtrang = 1;
            UpdateModel(tt);
            db.SubmitChanges();
            return RedirectToAction("DonHang");
        }

        [HttpGet]
        public ActionResult XoaDonHang(int id)
        {
            return View(db.DONHANGs.First(n => n.mahoadon == id));
        }
        [HttpPost, ActionName("XoaDonHang")]
        public ActionResult XacNhanXoaDonHang(int id)
        {
            var hd = db.HOADONs.First(n => n.mahoadon == id);
            db.HOADONs.DeleteOnSubmit(hd);
            db.SubmitChanges();
            return RedirectToAction("XoaThanhCong");
        }
        #endregion

        #region Quan ly nha san xuat
        public ActionResult QuanLyNhaSanXuat()
        {
            return View(db.NHASANXUATs.ToList());
        }
        [HttpGet]
        public ActionResult ThemMoiNhaSanXuat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiNhaSanXuat(NHASANXUAT nsx)
        {
            db.NHASANXUATs.InsertOnSubmit(nsx);
            db.SubmitChanges();
            return RedirectToAction("ThemThanhCong");
        }
        [HttpGet]
        public ActionResult SuaNhaSanXuat(int id)
        {
            return View(db.NHASANXUATs.First(n=>n.mansx==id));
        }
        [HttpPost]
        public ActionResult SuaNhaSanXuat(int id,FormCollection f)
        {
            var nsx = db.NHASANXUATs.First(n => n.mansx == id);
            UpdateModel(nsx);
            db.SubmitChanges();
            return RedirectToAction("SuaThanhCong");
        }
        [HttpGet]
        public ActionResult XoaNhaSanXuat(int id)
        {
            return View(db.NHASANXUATs.First(n => n.mansx == id));
        }
        [HttpPost,ActionName("XoaNhaSanXuat")]
        public ActionResult XacNhanXoaNSX(int id)
        {
            var nsx = db.NHASANXUATs.First(n => n.mansx == id);
            db.NHASANXUATs.DeleteOnSubmit(nsx);
            db.SubmitChanges();
            return RedirectToAction("XoaThanhCong");
        }
        #endregion

        #region Quan ly loai san pham
        public ActionResult QuanLyLoaiSanPham()
        {
            return View(db.LOAISANPHAMs.ToList());
        }
        [HttpGet]
        public ActionResult ThemMoiLoaiSanPham()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiLoaiSanPham(LOAISANPHAM lsp)
        {
            db.LOAISANPHAMs.InsertOnSubmit(lsp);
            db.SubmitChanges();
            return RedirectToAction("ThemThanhCong");
        }
        [HttpGet]
        public ActionResult SuaLoaiSanPham(int id)
        {
            return View(db.LOAISANPHAMs.First(n => n.maloai == id));
        }
        [HttpPost]
        public ActionResult SuaLoaiSanPham(int id, FormCollection f)
        {
            var lsp = db.LOAISANPHAMs.First(n => n.maloai == id);
            UpdateModel(lsp);
            db.SubmitChanges();
            return RedirectToAction("SuaThanhCong");
        }
        [HttpGet]
        public ActionResult XoaLoaiSanPham(int id)
        {
            return View(db.LOAISANPHAMs.First(n => n.maloai == id));
        }
        [HttpPost, ActionName("XoaLoaiSanPham")]
        public ActionResult XacNhanXoaLSP(int id)
        {
            var lsp = db.LOAISANPHAMs.First(n => n.maloai == id);
            db.LOAISANPHAMs.DeleteOnSubmit(lsp);
            db.SubmitChanges();
            return RedirectToAction("XoaThanhCong");
        }
        #endregion

        public ActionResult GiaoVan()
        {
            return View(db.DONHANGs.Where(n=>n.tinhtrang==1).ToList());
        }

        public ActionResult ThongKe()
        {
            ViewBag.TongTien = db.THONGKEs.Where(n => n.tinhtrang == 1).Sum(n => n.Tổng_tiền);
            return View(db.THONGKEs.Where(n => n.tinhtrang == 1).ToList());
        }
    }
}