namespace Doan16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
            PhieuHens = new HashSet<PhieuHen>();
        }

        [Key]
        public int id_KhachHang { get; set; }

        [Required]
        [StringLength(100)]
        public string tenKhachHang { get; set; }

        [Required]
        [StringLength(15)]
        public string TenDN { get; set; }

        [Required]
        [StringLength(32)]
        public string Matkhau { get; set; }

        [Required]
        [StringLength(100)]
        public string diachi { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Ngaysinh { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public bool? Gioitinh { get; set; }

        [Required]
        [StringLength(20)]
        public string SoDienThoai { get; set; }

        public int? SoTienConNo { get; set; }

        public bool? Duyet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuHen> PhieuHens { get; set; }
    }
}
