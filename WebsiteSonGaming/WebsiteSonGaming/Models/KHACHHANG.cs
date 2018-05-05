namespace WebsiteSonGaming.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            HOADON = new HashSet<HOADON>();
        }

        [Key]
        public int makh { get; set; }

        [StringLength(250)]
        public string tenkhachhang { get; set; }

        [StringLength(250)]
        public string taikhoan { get; set; }

        [StringLength(250)]
        public string matkhau { get; set; }

        [StringLength(250)]
        public string sodienthoai { get; set; }

        [StringLength(250)]
        public string diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADON { get; set; }
    }
}
