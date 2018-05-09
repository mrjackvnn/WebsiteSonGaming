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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuanLySanPham(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.SANPHAMs.OrderBy(n => n.masanpham).ToList().ToPagedList(pageNumber, pageSize));
        }

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

                ADMIN ad = db.ADMINs.First(n => n.username == tendn && n.password == matkhau);
                if (ad != null)
                {
                    // ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("QuanLySanPham", "Admin");
                }
                else
                {
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }

            }
            return View();
        }
        #endregion

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
                sp.hinhsanpham = fileName;
                //Luu vao CSDL
                db.SANPHAMs.InsertOnSubmit(sp);
                db.SubmitChanges();
                return RedirectToAction("ThemThanhCong");
            }
            return View();
        }
        #endregion


        public ActionResult ThemThanhCong()
        {
            return View();
        }

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
            return RedirectToAction("QuanLySanPham");
        }
        #endregion

        //Hiển thị sản phẩm
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

        #region Sua San Pham
        [HttpGet]
        public ActionResult SuaSanPham(int id)
        {
            var sp = db.SANPHAMs.First(n => n.masanpham == id);
            //Dua du lieu vao dropdownload
            ViewBag.MaLoai = new SelectList(db.LOAISANPHAMs.ToList().OrderBy(n => n.tenloai), "maloai", "tenloai");
            ViewBag.MaNsx = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.tennsx), "mansx", "tennsx");
            return View(sp);
        }
        //Chinh sửa sản phẩm
        [HttpPost]
        public ActionResult SuaSanPham(int id,FormCollection f)
        {
            var sp = db.SANPHAMs.First(n => n.masanpham == id);
            //Dua du lieu vao dropdownload
            ViewBag.MaLoai = new SelectList(db.LOAISANPHAMs.ToList().OrderBy(n => n.tenloai), "maloai", "tenloai");
            ViewBag.MaNsx = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.tennsx), "mansx", "tennsx");
            //Luu vao CSDL
            UpdateModel(sp);
            db.SubmitChanges();
            return RedirectToAction("QuanLySanPham");
        }
        #endregion

    }
}
