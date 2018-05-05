namespace WebsiteSonGaming.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        [Key]
        [StringLength(250)]
        public string username { get; set; }

        [StringLength(250)]
        public string password { get; set; }
    }
}
