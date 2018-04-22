namespace Doan16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuHen")]
    public partial class PhieuHen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuHen()
        {
            ChiTietPhieuHens = new HashSet<ChiTietPhieuHen>();
        }

        [Key]
        public int id_PhieuHen { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaylapphieu { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngayhen { get; set; }

        public int? id_KhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuHen> ChiTietPhieuHens { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
