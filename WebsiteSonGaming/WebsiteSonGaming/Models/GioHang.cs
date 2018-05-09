using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebsiteSonGaming.Models;

namespace WebsiteSonGaming.Models
{
    public class GioHang
    {
        SonGamingDataContext db = new SonGamingDataContext();

        [Display(Name = "Mã Sản Phẩm")]
        public int imasanpham { set; get; }

        [Display(Name = "Tên Sản Phẩm")]
        public string strtensanpham { set; get; }

        [Display(Name = "Hình Sản Phẩm")]
        public string strhinhsanpham { set; get; }

        [Display(Name = "Giá Bán")]
        public Double dgiaban { set; get; }

        [Display(Name = "Số Lượng")]
        public int isoluong { set; get; }

        [Display(Name = "Thành Tiền")]
        public Double dthanhtien
        {
            get { return isoluong * dgiaban; }

        }
        //Khoi tao gio hàng theo Masach duoc truyen vao voi Soluong mac dinh la 1
        public GioHang(int masanpham)
        {
            imasanpham = masanpham;
            SANPHAM sp = db.SANPHAMs.Single(n => n.masanpham == imasanpham);
            strtensanpham = sp.tensanpham;
            strhinhsanpham = sp.hinhsanpham;
            dgiaban = double.Parse(sp.giaban.ToString());
            isoluong = 1;
        }
    }
}