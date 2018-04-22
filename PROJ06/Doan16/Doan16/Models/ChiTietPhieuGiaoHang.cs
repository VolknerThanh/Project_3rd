namespace Doan16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuGiaoHang")]
    public partial class ChiTietPhieuGiaoHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_PhieuGiao { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_NuocGK { get; set; }

        public int? SoLuongGiao { get; set; }

        public int? DonGiaGiao { get; set; }

        public virtual NuocGK NuocGK { get; set; }

        public virtual PhieuGiaoHang PhieuGiaoHang { get; set; }
    }
}
