using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doan16.Filters;
using Doan16.Models;

namespace Doan16.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        QLCuaHangDBManage db = new QLCuaHangDBManage();
        // GET: Admin

        public List<KhachHang> laykhachhang()
        {
            var kh = (from s in db.KhachHangs
                      orderby s.id_KhachHang descending
                      select s).ToList();
            return kh;
        }
        [AdminFilters]
        public ActionResult KhachHang()
        {
            var kh = laykhachhang();
            return View(kh.ToList());
        }

        public ActionResult DuyetKH(int id)
        {
            KhachHang kh = db.KhachHangs.Find(id);
            kh.Duyet = true;
            db.Entry(kh).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("KhachHang");
        }
        public ActionResult XoaKH(int id)
        {
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.id_KhachHang == id);
            //ViewBag.id_NuocGK = ngk.id_NuocGK;
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);

        }
        [HttpPost, ActionName("XoaKH")]
        public ActionResult XacnhanxoaKH(int id)
        {
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.id_KhachHang == id);
            ViewBag.id_KhachHang = kh.id_KhachHang;
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KhachHangs.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("KhachHang");
        }


        #region Quản lý tài khoản nhân viên
        public List<TaiKhoan> laynhanvien()
        {
            var nv = (from s in db.TaiKhoans
                      orderby s.id descending
                      select s).ToList();
            return nv;
        }
        public ActionResult NhanVien()
        {
            var nv = laynhanvien();
            return View(nv.ToList());
        }

        public ActionResult DuyetNV(int id)
        {
            TaiKhoan nv = db.TaiKhoans.Find(id);
            nv.Duyet = true;
            db.Entry(nv).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("NhanVien");
        }
        public ActionResult XoaNV(int id)
        {
            TaiKhoan nv = db.TaiKhoans.SingleOrDefault(n => n.id == id);
            //ViewBag.id_NuocGK = ngk.id_NuocGK;
            if (nv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nv);

        }
        [HttpPost, ActionName("XoaNV")]
        public ActionResult XacnhanxoaNV(int id)
        {
            TaiKhoan nv = db.TaiKhoans.SingleOrDefault(n => n.id == id);
            ViewBag.id = nv.id;
            if (nv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.TaiKhoans.Remove(nv);
            db.SaveChanges();
            return RedirectToAction("NhanVien");
        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }


        #region Lấy sản phẩm
        public List<NuocGK> layspmoi()
        {
            var sp = (from s in db.NuocGKs
                      orderby s.id_NuocGK descending
                      select s).ToList();
            return sp;
        }
        public ActionResult SanPham()
        {
            var sp = layspmoi();
            return View(sp.ToList());
        }
        #endregion
        #region Thêm mới sản phẩm
        [HttpGet]
        public ActionResult ThemmoiSP()
        {
            ViewBag.nhanhieuNGK = new SelectList(db.LoaiNGKs.ToList().OrderBy(n => n.TenLoaiNGK), "id_LoaiNGK", "TenLoaiNGK");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemmoiSP(NuocGK ngk, HttpPostedFileBase fileupload)
        {
            ViewBag.nhanhieuNGK = new SelectList(db.LoaiNGKs.ToList().OrderBy(n => n.TenLoaiNGK), "id_LoaiNGK", "TenLoaiNGK");
            if (fileupload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileName(fileupload.FileName);
                var path = Path.Combine(Server.MapPath("~/images"), filename);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileupload.SaveAs(path);
                }
                ngk.hinhanh = filename;
                db.NuocGKs.Add(ngk);
                db.SaveChanges();
                return RedirectToAction("SanPham");
            }
            return View();
        }
        #endregion
        #region Chi tiết sản phẩm
        public ActionResult ChitietSP(int id)
        {
            NuocGK ngk = db.NuocGKs.SingleOrDefault(n => n.id_NuocGK == id);
            ViewBag.id_NuocGK = ngk.id_NuocGK;
            if (ngk == null)
            {
                Response.StatusCode = 404;
            }
            return View(ngk);
        }
        #endregion
        #region Xóa sản phẩm
        public ActionResult XoaSP(int id)
        {
            NuocGK ngk = db.NuocGKs.SingleOrDefault(n => n.id_NuocGK == id);
            //ViewBag.id_NuocGK = ngk.id_NuocGK;
            if (ngk == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ngk);
        }
        [HttpPost, ActionName("XoaSP")]
        public ActionResult Xacnhanxoa(int id)
        {
            NuocGK ngk = db.NuocGKs.SingleOrDefault(n => n.id_NuocGK == id);
            ViewBag.id_NuocGK = ngk.id_NuocGK;
            if (ngk == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NuocGKs.Remove(ngk);
            db.SaveChanges();
            return RedirectToAction("SanPham");
        }
        #endregion
        #region Sửa sản phẩm
        [HttpGet]
        public ActionResult SuaSP(int id)
        {
            NuocGK ngk = db.NuocGKs.SingleOrDefault(n => n.id_NuocGK == id);
            if (ngk == null)
            {
                Response.StatusCode = 404;
            }
            ViewBag.nhanhieuNGK = new SelectList(db.LoaiNGKs.ToList().OrderBy(n => n.TenLoaiNGK), "id_LoaiNGK", "TenLoaiNGK");
            return View(ngk);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaSP(NuocGK ngk, HttpPostedFileBase fileupload)
        {
            ViewBag.nhanhieuNGK = new SelectList(db.LoaiNGKs.ToList().OrderBy(n => n.TenLoaiNGK), "id_LoaiNGK", "TenLoaiNGK");
            if (fileupload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileName(fileupload.FileName);
                var path = Path.Combine(Server.MapPath("~/images"), filename);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileupload.SaveAs(path);
                }
                NuocGK n = db.NuocGKs.Where(x => x.id_NuocGK == ngk.id_NuocGK).Single<NuocGK>();
                n.nhanhieuNGK = ngk.nhanhieuNGK;
                n.tenNGK = ngk.tenNGK;
                n.dongia = ngk.dongia;
                n.soluongton = ngk.soluongton;
                ngk.hinhanh = filename;
                db.SaveChanges();
            }
            return RedirectToAction("SanPham");
        }
        #endregion

        #region Lấy nhà cung ứng
        public List<NhaCungUng> layncu()
        {
            var ncu = (from s in db.NhaCungUngs
                       orderby s.id_NhaCungUng descending
                       select s).ToList();
            return ncu;
        }
        public ActionResult NhaCungUng()
        {
            var ncu = layncu();
            return View(ncu.ToList());
        }

        public int Insert(NhaCungUng model)
        {
            db.NhaCungUngs.Add(model);
            db.SaveChanges();
            return model.id_NhaCungUng;
        }
        #endregion
        #region Thêm mới nhà cung ứng
        public ActionResult ThemmoiNCU()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemmoiNCU(NhaCungUng ncu)
        {
            if (ModelState.IsValid)
            {
                var id = Insert(ncu);
                if (id > 0)
                {
                    return RedirectToAction("NhaCungUng");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công!");
                }
            }
            return View(ncu);
        }
        #endregion
        #region Sửa nhà cung ứng
        [HttpGet]
        public ActionResult SuaNCU(int id)
        {
            NhaCungUng ncu = db.NhaCungUngs.SingleOrDefault(n => n.id_NhaCungUng == id);
            if (ncu == null)
            {
                Response.StatusCode = 404;
            }
            return View(ncu);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaNCU(NhaCungUng ncu)
        {
            if (ModelState.IsValid)
            {
                NhaCungUng n = db.NhaCungUngs.Where(x => x.id_NhaCungUng == ncu.id_NhaCungUng).Single<NhaCungUng>();
                n.TenNhaCungUng = ncu.TenNhaCungUng;
                n.DiaChi = ncu.DiaChi;
                n.SDT = ncu.SDT;
                db.SaveChanges();
            }
            return RedirectToAction("NhaCungUng");
        }
        #endregion
        #region Xóa nhà cung ứng
        public ActionResult XoaNCU(int id)
        {
            NhaCungUng ncu = db.NhaCungUngs.SingleOrDefault(n => n.id_NhaCungUng == id);
            ViewBag.id_NuocGK = ncu.id_NhaCungUng;
            if (ncu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ncu);
        }
        [HttpPost, ActionName("XoaNCU")]
        public ActionResult XacnhanxoaNCU(int id)
        {
            NhaCungUng ncu = db.NhaCungUngs.SingleOrDefault(n => n.id_NhaCungUng == id);
            ViewBag.id_NhaCungUng = ncu.id_NhaCungUng;
            if (ncu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NhaCungUngs.Remove(ncu);
            db.SaveChanges();
            return RedirectToAction("NhaCungUng");
        }
        #endregion
        #region Chi tiết nhà cung ứng
        public ActionResult ChitietNCU(int id)
        {
            NhaCungUng ncu = db.NhaCungUngs.SingleOrDefault(n => n.id_NhaCungUng == id);
            ViewBag.id_NhaCungUng = ncu.id_NhaCungUng;
            if (ncu == null)
            {
                Response.StatusCode = 404;
            }
            return View(ncu);
        }
        #endregion

        #region Lấy loại nước giải khát
        public List<LoaiNGK> laylngk()
        {
            var lngk = (from s in db.LoaiNGKs
                        orderby s.id_LoaiNGK descending
                        select s).ToList();
            return lngk;
        }
        public ActionResult LoaiNGK()
        {
            var lngk = laylngk();
            return View(lngk.ToList());
        }

        public int InsertLNGK(LoaiNGK model)
        {
            db.LoaiNGKs.Add(model);
            db.SaveChanges();
            return model.id_LoaiNGK;
        }
        #endregion
        #region Thêm loại nước giải khát
        public ActionResult ThemmoiLNGK()
        {
            ViewBag.NhaCungUng = new SelectList(db.NhaCungUngs.ToList().OrderBy(n => n.TenNhaCungUng), "id_NhaCungUng", "TenNhaCungUng");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemmoiLNGK(LoaiNGK lngk)
        {
            ViewBag.NhaCungUng = new SelectList(db.NhaCungUngs.ToList().OrderBy(n => n.TenNhaCungUng), "id_NhaCungUng", "TenNhaCungUng");
            if (ModelState.IsValid)
            {
                var id = InsertLNGK(lngk);
                if (id > 0)
                {
                    return RedirectToAction("LoaiNGK");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công!");
                }
            }
            return View(lngk);
        }
        #endregion
        #region Sửa loại nước giải khát
        public ActionResult SuaLNGK(int id)
        {
            LoaiNGK lngk = db.LoaiNGKs.SingleOrDefault(x => x.id_LoaiNGK == id);
            if (lngk == null)
            {
                Response.StatusCode = 404;
            }
            ViewBag.NhaCungUng = new SelectList(db.NhaCungUngs.ToList().OrderBy(n => n.TenNhaCungUng), "id_NhaCungUng", "TenNhaCungUng");
            return View(lngk);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaLNGK(LoaiNGK lngk)
        {
            ViewBag.NhaCungUng = new SelectList(db.NhaCungUngs.ToList().OrderBy(n => n.TenNhaCungUng), "id_NhaCungUng", "TenNhaCungUng");
            if (ModelState.IsValid)
            {
                LoaiNGK l = db.LoaiNGKs.Where(x => x.id_LoaiNGK == lngk.id_LoaiNGK).Single<LoaiNGK>();
                l.TenLoaiNGK = lngk.TenLoaiNGK;
                l.NhaCungUng = lngk.NhaCungUng;
                db.SaveChanges();
            }
            return RedirectToAction("LoaiNGK");
        }
        #endregion
        #region Xóa loại nước giải khát
        public ActionResult XoaLNGK(int id)
        {
            LoaiNGK lngk = db.LoaiNGKs.SingleOrDefault(n => n.id_LoaiNGK == id);
            ViewBag.id_NuocGK = lngk.id_LoaiNGK;
            if (lngk == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(lngk);
        }
        [HttpPost, ActionName("XoaLNGK")]
        public ActionResult XacnhanxoaLNGK(int id)
        {
            LoaiNGK lngk = db.LoaiNGKs.SingleOrDefault(n => n.id_LoaiNGK == id);
            ViewBag.id_NhaCungUng = lngk.id_LoaiNGK;
            if (lngk == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.LoaiNGKs.Remove(lngk);
            db.SaveChanges();
            return RedirectToAction("LoaiNGK");
        }
        #endregion
        #region Chi tiết loại nước giải khát
        public ActionResult ChitietLNGK(int id)
        {
            LoaiNGK lngk = db.LoaiNGKs.SingleOrDefault(n => n.id_LoaiNGK == id);
            ViewBag.id_LoaiNGK = lngk.id_LoaiNGK;
            if (lngk == null)
            {
                Response.StatusCode = 404;
            }
            return View(lngk);
        }
        #endregion
        

        [HttpPost]
        public ActionResult Logout()
        {
            Session["TaiKhoanAdmin"] = null;

            return RedirectToAction("Index", "SanPham");
        }
        public ActionResult NotAuthentication()
        {
            return View();
        }
    }
}
