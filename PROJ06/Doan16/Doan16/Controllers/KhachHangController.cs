using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Doan16.Models;

namespace Doan16.Controllers
{
    public class KhachHangController : Controller
    {
        QLCuaHangDBManage db = new QLCuaHangDBManage();
        // GET: KhachHang
        public ActionResult Index()
        {
            return View();
        }
        public bool CheckExistUsername(string username)
        {
            var tendn = (from tk in db.KhachHangs
                         where tk.TenDN == username
                         select tk).ToList();

            if (tendn.Count != 0) // tim duoc
                return false;
            return true;
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection col, KhachHang kh)
        {
            var hoten = col["Hoten"];
            var tendn = col["TenDN"];
            var matkhau = col["Matkhau"];
            var matkhaunhaplai = col["Matkhaunhaplai"];
            var diachi = col["Diachi"];
            var email = col["Email"];
            var dienthoai = col["Dienthoai"];
            var gioitinh = col["Gioitinh"];
            DateTime ngaysinh = DateTime.Parse(col["Ngaysinh"]);
            
            if (!CheckExistUsername(tendn))
            {
                ViewData["Loi9"] = "Trùng tên đăng nhập !";
                return this.DangKy();
            }
            if(DateTime.Now.Year - ngaysinh.Year < 15 || (ngaysinh.Day > DateTime.Now.Day && ngaysinh.Month > DateTime.Now.Month && ngaysinh.Year > DateTime.Now.Year))
            {
                ViewData["Loi10"] = "Tuổi người dùng quá nhỏ!";
                return this.DangKy();
            }

            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên khách hàng không được để trống";
            }
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Phải nhập tên đăng nhập";
            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Phải nhập mật khẩu";
            }
            if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi4"] = "Phải nhập lại mật khẩu";
            }
            if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi5"] = "Địa chỉ không được để trống";
            }
            if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi6"] = "Email không được để trống";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi7"] = "Phải nhập điện thoại";
            }
            if (matkhaunhaplai != matkhau)
            {
                ViewData["Loi4"] = "Mật khẩu nhập lại sai!";
            }
            else
            {
                kh.tenKhachHang = hoten;
                kh.TenDN = tendn;
                kh.Matkhau = MaHoa.Encryptor.MD5Hash(matkhau);
                kh.Email = email;
                kh.diachi = diachi;
                kh.SoDienThoai = dienthoai;
                kh.Ngaysinh = ngaysinh;
                kh.Gioitinh = bool.Parse(gioitinh);
                kh.SoTienConNo = 0;
                kh.Duyet = false;
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Dangnhap");
            }            
            return this.DangKy();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dangnhap(FormCollection col)
        {
            var tendn = col["TenDN"];
            var matkhau = MaHoa.Encryptor.MD5Hash(col["Matkhau"]);
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TenDN == tendn && n.Matkhau == matkhau);
                if (kh != null)
                {
                    ViewBag.Thongbao = "Chúc mừng đặng nhập thành công";
                    Session["TaiKhoan"] = kh;
                    Session["LoaiTaiKhoan"] = kh.Duyet;
                    Session["TenDangNhap"] = tendn;
                    return RedirectToAction("DisplayCart", "Cart", new { area = "" });
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["TaiKhoan"] = null;
            Session["TenDangNhap"] = null;
            Session["LoaiTaiKhoan"] = null;
            Session.Clear();

            return RedirectToAction("Index", "SanPham");
        }
    }
}