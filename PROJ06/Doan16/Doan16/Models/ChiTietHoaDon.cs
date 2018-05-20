namespace Doan16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_HoaDon { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_NuocGK { get; set; }
        [Required]
        public int soluongmua { get; set; }

        public int? dongiaban { get; set; }

        public int? thanhtien { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual NuocGK NuocGK { get; set; }
    }
}
