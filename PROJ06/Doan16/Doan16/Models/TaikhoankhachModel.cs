using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan16.Models
{
    public class TaikhoankhachModel
    {
        private QLCuaHangDBManage context = null;
        public TaikhoankhachModel()
        {
            context = new QLCuaHangDBManage();
        }

        public List<KhachHang> ListAll()
        {
            var list = context.Database.SqlQuery<KhachHang>("Sp_TaiKhoan_Duyet").ToList();
            return list;
        }
    }
}