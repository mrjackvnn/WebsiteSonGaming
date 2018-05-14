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
        public int imasanpham { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        public string strtensanpham { get; set; }

        [Display(Name = "Hình Sản Phẩm")]
        public string strhinhsanpham { get; set; }

        [Display(Name = "Giá Bán")]
        public Double dgiaban { get; set; }

        [Display(Name = "Số Lượng")]
        public int isoluong { get; set; }

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