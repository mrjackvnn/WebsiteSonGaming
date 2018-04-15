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
            [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
            public string taikhoan { get; set; }

            [Display(Name = "Mật khẩu")]
            [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 kí tự !")]
            [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
            public string matkhau { get; set; }

            [Display(Name = "Điện thoại")]
            [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
            public string sodienthoai { get; set; }

            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "Yêu cầu nhập địa chỉ")]
            public string diachi { get; set; }

            [Display(Name = "Họ tên")]
            [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
            public string tenkhachhang { get; set; }
        }
    }
}
