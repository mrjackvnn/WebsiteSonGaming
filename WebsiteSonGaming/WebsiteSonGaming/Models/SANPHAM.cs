//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebsiteSonGaming.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            this.CHITIETHOADON = new HashSet<CHITIETHOADON>();
        }
    
        public int masanpham { get; set; }
        public Nullable<int> mansx { get; set; }
        public Nullable<int> maloai { get; set; }
        public string tensanpham { get; set; }
        public Nullable<double> giaban { get; set; }
        public Nullable<System.DateTime> ngaycapnhat { get; set; }
        public string hinhsanpham { get; set; }
        public string thongtin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADON { get; set; }
        public virtual LOAISANPHAM LOAISANPHAM { get; set; }
        public virtual NHASANXUAT NHASANXUAT { get; set; }
    }
}