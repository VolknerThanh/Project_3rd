namespace Doan16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NuocGK")]
    public partial class NuocGK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NuocGK()
        {
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            ChiTietPhieuGiaoHangs = new HashSet<ChiTietPhieuGiaoHang>();
            ChiTietPhieuHens = new HashSet<ChiTietPhieuHen>();
        }

        [Key]
        public int id_NuocGK { get; set; }

        [Required]
        [StringLength(50)]
        public string tenNGK { get; set; }

        public int dongia { get; set; }

        public int? nhanhieuNGK { get; set; }

        public int? soluongton { get; set; }

        [StringLength(200)]
        public string hinhanh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuGiaoHang> ChiTietPhieuGiaoHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuHen> ChiTietPhieuHens { get; set; }

        public virtual LoaiNGK LoaiNGK { get; set; }
    }
}
