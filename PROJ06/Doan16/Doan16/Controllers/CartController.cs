using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Doan16.Models;

namespace Doan16.Controllers
{
    public class CartController : Controller
    {
        QLCuaHangDBManage data = new QLCuaHangDBManage();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public List<Cart> getCart()
        {
            List<Cart> listCart = Session["Cart"] as List<Cart>;
            if(listCart == null)
            {
                listCart = new List<Cart>();
                Session["Cart"] = listCart;
            }
            return listCart;
        }
        public ActionResult AddToCart(int id, string Url, FormCollection collection)
        {
            List<Cart> listCart = getCart();
            Cart item = listCart.Find(n => n.id_NGK == id);

            int soluongmua = int.Parse(collection["SoLuongMua"].ToString());

            if (item == null)
            {
                item = new Cart(id);
                item.quantity_NGK = soluongmua;
                listCart.Add(item);
            }
            else
                item.quantity_NGK += soluongmua;
            

            return Redirect(Url);
        }
        public int SumQuantity()
        {
            int sum = 0;
            List<Cart> listCart = Session["Cart"] as List<Cart>;
            if (listCart != null)
                sum = listCart.Sum(n => n.quantity_NGK);

            return sum;
        }
        public double TotalPrice()
        {
            double total = 0;
            List<Cart> listCart = Session["Cart"] as List<Cart>;
            if (listCart != null)
                total = listCart.Sum(n => n.totalPrice_NGK);
            return total;
        }
        public ActionResult DisplayCart()
        {
            List<Cart> listCart = getCart();

            ViewBag.TongSoLuong = SumQuantity();
            ViewBag.TongThanhTien = TotalPrice();
            return View(listCart);
        }
        
    }
}