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

            int soluongmua = 1;

            if(collection["SoLuongMua"] != null)
                soluongmua = int.Parse(collection["SoLuongMua"].ToString());

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
        public ActionResult CartInformation()
        {
            ViewBag.TongSoLuong = SumQuantity();
            ViewBag.TongThanhTien = TotalPrice();
            return PartialView();
        }
        public ActionResult UpdateCart(int id, FormCollection collector)
        {
            List<Cart> listCart = getCart();

            Cart item = listCart.SingleOrDefault(n => n.id_NGK == id);

            if (item != null)
                item.quantity_NGK = int.Parse(collector["txtQuantity"].ToString());

            return RedirectToAction("DisplayCart");
        }
        public ActionResult RemoveCart(int id)
        {
            List<Cart> listCart = getCart();

            Cart item = listCart.SingleOrDefault(n => n.id_NGK == id);

            if(item != null)
                listCart.RemoveAll(n => n.id_NGK == id);
            
            return RedirectToAction("DisplayCart");
        }
        public ActionResult RemoveAllCart()
        {
            List<Cart> listCart = getCart();

            if(listCart != null)
                listCart.Clear();

            return RedirectToAction("Index", "SanPham");
        }
        public List<Cart> CheckQuantity(List<Cart> ds)
        {
            List<Cart> dssp = new List<Cart>();
            foreach (var item in ds)
            {
                if (item.quantity_NGK > item.quantity_of_product)
                    dssp.Add(item);
            }
            return dssp;
        }
        //[HttpGet]
        public ActionResult Order()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("Index", "SanPham");

            if (Session["TaiKhoan"] == null)
                return RedirectToAction("DangNhap", "KhachHang");

            List<Cart> listCart = getCart();
            List<Cart> SanPhamVuotSoLuong = new List<Cart>(CheckQuantity(listCart));

            Tuple<List<Cart>, List<Cart>> danhsachsp = new Tuple<List<Cart>, List<Cart>>(listCart, SanPhamVuotSoLuong);
            

            if (SanPhamVuotSoLuong.Count() != 0)
            {
                // co ton tai san pham > so luong ton
                ViewBag.ThongBao = "notEnough";
                //return View(SanPhamVuotSoLuong);
            }

            ViewBag.TongSoLuong = SumQuantity();
            ViewBag.TongThanhTien = TotalPrice();

            ViewBag.ThongBao = "Enough";
            return View(danhsachsp);
        }
    }
}