namespace Doan16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiNGK")]
    public partial class LoaiNGK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiNGK()
        {
            NuocGKs = new HashSet<NuocGK>();
        }

        [Key]
        public int id_LoaiNGK { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên loại nước giải khát")]
        [StringLength(100)]
        public string TenLoaiNGK { get; set; }

        public int? NhaCungUng { get; set; }

        public virtual NhaCungUng NhaCungUng1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NuocGK> NuocGKs { get; set; }
    }
}
