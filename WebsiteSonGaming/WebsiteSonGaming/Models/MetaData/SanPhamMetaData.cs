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
            [Required(ErrorMessage = "{0} Không được để trống")]
            public Nullable<int> mansx { get; set; }

            [Display(Name = "Loại Sản Phẩm")]
            [Required(ErrorMessage = "{0} Không được để trống")]
            public Nullable<int> maloai { get; set; }

            [Display(Name = "Tên Sản Phẩm")]
            [Required(ErrorMessage = "{0} Không được để trống")]
            public string tensanpham { get; set; }

            [Display(Name = "Giá Bán")]
            [Required(ErrorMessage = "{0} Không được để trống")]
            public Nullable<double> giaban { get; set; }

            [Display(Name = "Ngày Cập Nhật")]
            [Required(ErrorMessage = "{0} Không được để trống")]
            public Nullable<System.DateTime> ngaycapnhat { get; set; }

            [Display(Name = "Hình Sản Phẩm")]
            [Required(ErrorMessage = "{0} Không được để trống")]
            public string hinhsanpham { get; set; }

            [Display(Name = "Thông Tin")]
            [Required(ErrorMessage = "{0} Không được để trống")]
            public string thongtin { get; set; }
        }
    }
}