namespace WebsiteSonGaming.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CHITIETHOADON = new HashSet<CHITIETHOADON>();
        }

        [Key]
        public int masanpham { get; set; }

        public int? mansx { get; set; }

        public int? maloai { get; set; }

        [StringLength(250)]
        public string tensanpham { get; set; }

        public double? giaban { get; set; }

        public DateTime? ngaycapnhat { get; set; }

        [StringLength(250)]
        public string hinhsanpham { get; set; }

        [Column(TypeName = "ntext")]
        public string thongtin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADON { get; set; }

        public virtual LOAISANPHAM LOAISANPHAM { get; set; }

        public virtual NHASANXUAT NHASANXUAT { get; set; }
    }
}
