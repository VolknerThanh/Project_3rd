namespace Doan16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuTraNo")]
    public partial class PhieuTraNo
    {
        [Key]
        public int id_PhieuTraNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayTra { get; set; }

        public int SoTienTra { get; set; }

        public int? id_HoaDon { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
