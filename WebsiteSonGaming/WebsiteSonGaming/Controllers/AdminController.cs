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

namespace WebsiteSonGaming.Controllers
{
    public class AdminController : Controller
    {
        SonGamingEntities db = new SonGamingEntities();
        // GET: Admin
        public ActionResult QuanLySanPham(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.SANPHAM.OrderBy(n=>n.masanpham).ToList().ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult ThemMoiSanPham()
        {
            //Dua du lieu vao dropdownList
            //Lay ds tu tabke chu de, sắp xep tang dan trheo ten chu de, chon lay gia tri Ma CD, hien thi thi Tenchude
            ViewBag.MaLoai = new SelectList(db.LOAISANPHAM.ToList().OrderBy(n => n.tenloai), "maloai", "tenloai");
            ViewBag.MaNsx = new SelectList(db.NHASANXUAT.ToList().OrderBy(n => n.tennsx), "mansx", "tennsx");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoiSanPham(SANPHAM sp, HttpPostedFileBase fileUpload)
        {
            //Dua du lieu vao dropdownload
            ViewBag.MaLoai = new SelectList(db.LOAISANPHAM.ToList().OrderBy(n => n.tenloai), "maloai", "tenloai");
            ViewBag.MaNsx = new SelectList(db.NHASANXUAT.ToList().OrderBy(n => n.tennsx), "mansx", "tennsx");
            //Kiem tra duong dan file
            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            //Them vao CSDL
            else
            {
                if (ModelState.IsValid)
                {
                    //Luu ten fie, luu y bo sung thu vien using System.IO;
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //Luu duong dan cua file
                    var path = Path.Combine(Server.MapPath("~/Images/HinhSanPham/"), fileName);
                    //Kiem tra hình anh ton tai chua?
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                    {
                        //Luu hinh anh vao duong dan
                        fileUpload.SaveAs(path);
                    }
                    sp.hinhsanpham = fileName;
                    //Luu vao CSDL
                    db.SANPHAM.Add(sp);
                    db.SaveChanges();
                }
                return RedirectToAction("QuanLySanPham");
            }
        }

        //Hiển thị sản phẩm
        public ActionResult ChiTietSanPham(int id)
        {
            //Lay ra doi tuong sach theo ma
            SANPHAM sp = db.SANPHAM.SingleOrDefault(n => n.masanpham == id);
            ViewBag.MaSanPham = sp.masanpham;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }

        [HttpGet]
        public ActionResult XoaSanPham(int id)
        {
            //Lay ra doi tuong sach can xoa theo ma
            SANPHAM sp = db.SANPHAM.SingleOrDefault(n => n.masanpham == id);
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
            SANPHAM sp = db.SANPHAM.SingleOrDefault(n => n.masanpham == id);
            ViewBag.MaSanPham = sp.masanpham;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SANPHAM.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("QuanLySanPham");
        }
        //Chinh sửa sản phẩm
        [HttpGet]
        public ActionResult SuaSanPham(int id)
        {
            //Lay ra doi tuong sach theo ma
            SANPHAM sp = db.SANPHAM.SingleOrDefault(n => n.masanpham == id);
            ViewBag.MaSanPham = sp.masanpham;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Dua du lieu vao dropdownList
            //Lay ds tu tabke chu de, sắp xep tang dan trheo ten chu de, chon lay gia tri Ma CD, hien thi thi Tenchude
            ViewBag.MaLoai = new SelectList(db.LOAISANPHAM.ToList().OrderBy(n => n.tenloai), "maloai", "tenloai");
            ViewBag.MaNsx = new SelectList(db.NHASANXUAT.ToList().OrderBy(n => n.tennsx), "mansx", "tennsx");
            return View(sp);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaSanPham(SANPHAM sp, HttpPostedFileBase fileUpload)
        {
            //Dua du lieu vao dropdownload
            ViewBag.MaLoai = new SelectList(db.LOAISANPHAM.ToList().OrderBy(n => n.tenloai), "maloai", "tenloai");
            ViewBag.MaNsx = new SelectList(db.NHASANXUAT.ToList().OrderBy(n => n.tennsx), "mansx", "tennsx");
            //Kiem tra duong dan file
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            //Them vao CSDL
            else
            {
                if (ModelState.IsValid)
                {
                    //Luu ten fie, luu y bo sung thu vien using System.IO;
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //Luu duong dan cua file
                    var path = Path.Combine(Server.MapPath("~/Images/HinhSanPham/"), fileName);
                    //Kiem tra hình anh ton tai chua?
                    if (System.IO.File.Exists(path))
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    else
                    {
                        //Luu hinh anh vao duong dan
                        fileUpload.SaveAs(path);
                    }
                    sp.hinhsanpham = fileName;
                    //Luu vao CSDL   
                    UpdateModel(sp);
                    db.SaveChanges();

                }
                return RedirectToAction("QuanLySanPham");
            }
        }
    }
}