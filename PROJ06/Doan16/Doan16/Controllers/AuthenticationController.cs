using Doan16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Doan16.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        QLCuaHangDBManage db = new QLCuaHangDBManage();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoLogin(FormCollection fc)
        {
            if (ModelState.IsValid)
            {
                var tendn = fc["TenDN"].ToString();
                var matkhau = MaHoa.Encryptor.MD5Hash(fc["Matkhau"].ToString());
                Session["IsAdmin"] = false;
                TaiKhoan tk = db.TaiKhoans.SingleOrDefault(x => x.TenDangNhap == tendn && x.MatKhau == matkhau);
                if (tk != null)
                {
                    if (tk.Duyet == false)
                    {

                        ModelState.AddModelError("Perrmission", "Your account is still not activated");
                        return View("Login");
                    }
                    Session["TenDNAdmmin"] = tendn;
                    if (tk.PhanQuyen == true)
                    {
                        Session["IsAdmin"] = true;
                    }
                    else if (tk.PhanQuyen == false)
                    {
                        Session["IsAdmin"] = false;
                    }
                    FormsAuthentication.SetAuthCookie(tendn, false);
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("Login");
                }
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View("Login");
            }

        }
        public ActionResult Logout()
        {
            Session["TenDNAdmmin"] = null;
            Session["IsAdmin"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Authentication");
        }
    }
}