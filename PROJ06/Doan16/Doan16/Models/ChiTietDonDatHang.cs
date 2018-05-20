namespace Doan16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonDatHang")]
    public partial class ChiTietDonDatHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_DonDatHang { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_NuocGK { get; set; }
        [Required]
        public int SoLuongDat { get; set; }

        public virtual DonDatHang DonDatHang { get; set; }

        public virtual NuocGK NuocGK { get; set; }
    }
}
