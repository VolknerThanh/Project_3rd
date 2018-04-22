using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan16.Models
{
    public class NhanVienModel
    {
        private QLCuaHangDBManage context = null;
        public NhanVienModel()
        {
            context = new QLCuaHangDBManage();
        }

        public List<TaiKhoan> ListAll()
        {
            var list = context.Database.SqlQuery<TaiKhoan>("Sp_TaiKhoanNV_Duyet").ToList();
            return list;
        }
    }
}