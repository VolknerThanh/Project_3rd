using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Doan16.Models
{
    public class BK_HoaDon
    {
        [Key]
        public int id_HoaDon { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayXuatHD { get; set; }

        public int? id_KhachHang { get; set; }

        [StringLength(5)]
        public string soHD { get; set; }

        public int? TongTien { get; set; }
        public int Status { set; get; }
    }
}