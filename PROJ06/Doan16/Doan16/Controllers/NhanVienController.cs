using Doan16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan16.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        QLCuaHangDBManage db = new QLCuaHangDBManage();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        public bool CheckExistUsername(string username)
        {
            var tendn = (from tk in db.TaiKhoans
                         where tk.TenDangNhap == username
                         select tk).ToList();

            if (tendn.Count != 0) // tim duoc
                return false;
            return true;
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection col, TaiKhoan tk)
        {
            var tendn = col["TenDN"];
            var matkhau = col["Matkhau"];
            var matkhaunhaplai = col["Matkhaunhaplai"];
            var diachi = col["Diachi"];
            var dienthoai = col["Dienthoai"];

            if(!CheckExistUsername(tendn))
            {
                ViewData["Loi6"] = "Trùng tên đăng nhập !";
                return this.DangKy();
            }

            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi3"] = "Phải nhập lại mật khẩu";
            }
            else if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi4"] = "Địa chỉ không được để trống";
            }
            else if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi5"] = "Phải nhập điện thoại";
            }
            else if (matkhaunhaplai != matkhau)
            {
                ViewData["Loi3"] = "Mật khẩu nhập lại sai!";
            }
            else
            {
                tk.TenDangNhap = tendn;
                tk.MatKhau = MaHoa.Encryptor.MD5Hash(matkhau);
                tk.DiaChi = diachi;
                tk.SDT = dienthoai;
                tk.PhanQuyen = false;
                tk.Duyet = false;
                db.TaiKhoans.Add(tk);
                db.SaveChanges();
                return RedirectToAction("Login", "Authentication");
            }
            return this.DangKy();
        }
    }
}