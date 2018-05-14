using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebsiteSonGaming.Models
{
    [MetadataTypeAttribute(typeof(KhachHangMetaData))]
    public partial class KHACHHANG
    {
        internal sealed class KhachHangMetaData
        {
            public int makh { get; set; }

            [Display(Name = "Tên đăng nhập")]
            [Required(ErrorMessage = "{0} Không được để trống")]
            public string taikhoan { get; set; }

            [Display(Name = "Mật khẩu")]
            [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 kí tự !")]
            [Required(ErrorMessage = "{0} Không được để trống")]
            public string matkhau { get; set; }

            [Display(Name = "Điện thoại")]
            [Required(ErrorMessage = "{0} Không được để trống")]
            public string sodienthoai { get; set; }

            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "{0} Không được để trống")]
            public string diachi { get; set; }

            [Display(Name = "Họ tên")]
            [Required(ErrorMessage = "{0} Không được để trống")]
            public string tenkhachhang { get; set; }
        }
    }
}
