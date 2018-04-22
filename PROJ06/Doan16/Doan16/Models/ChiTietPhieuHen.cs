namespace Doan16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuHen")]
    public partial class ChiTietPhieuHen
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_NuocGK { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_PhieuHen { get; set; }

        public int? soluongHang { get; set; }

        public virtual NuocGK NuocGK { get; set; }

        public virtual PhieuHen PhieuHen { get; set; }
    }
}
