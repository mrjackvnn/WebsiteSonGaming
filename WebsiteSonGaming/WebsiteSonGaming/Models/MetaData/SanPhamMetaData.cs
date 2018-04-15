using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WebsiteSonGaming.Models
{
    [MetadataTypeAttribute(typeof(SanPhamMetaData))]
    public partial class SANPHAM
    {
        internal sealed class SanPhamMetaData
        {
            public int masanpham { get; set; }

            [Display(Name = "Nhà Sản Xuất")]
            public Nullable<int> mansx { get; set; }

            [Display(Name = "Loại Sản Phẩm")]
            public Nullable<int> maloai { get; set; }

            [Display(Name = "Tên Sản Phẩm")]
            public string tensanpham { get; set; }

            [Display(Name = "Giá Bán")]
            public Nullable<double> giaban { get; set; }

            [Display(Name = "Ngày Cập Nhật")]
            public Nullable<System.DateTime> ngaycapnhat { get; set; }

            [Display(Name = "Hình Sản Phẩm")]
            public string hinhsanpham { get; set; }

            [Display(Name = "Thông Tin")]
            public string thongtin { get; set; }
        }
    }
}