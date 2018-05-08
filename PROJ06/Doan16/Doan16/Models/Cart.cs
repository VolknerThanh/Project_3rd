using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Doan16.Models;
using System.Data.Entity;

namespace Doan16.Models
{
    public class Cart
    {
        QLCuaHangDBManage data = new QLCuaHangDBManage();
        public int id_NGK { set; get; }
        public string name_NGK { set; get; }
        public string img_NGK { set; get; }
        public int quantity_NGK { set; get; }
        public Double price_NGK { set; get; }
        public Double totalPrice_NGK { get { return quantity_NGK * price_NGK; } }
        public Cart(int id)
        {
            id_NGK = id;
            NuocGK item = data.NuocGKs.Single(n => n.id_NuocGK == id_NGK);
            name_NGK = item.tenNGK;
            img_NGK = item.hinhanh;
            price_NGK = double.Parse(item.dongia.ToString());
            quantity_NGK = 1;
        }
        
    }
}