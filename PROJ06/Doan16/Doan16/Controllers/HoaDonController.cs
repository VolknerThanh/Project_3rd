using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doan16.Filters;
using Doan16.Models;

namespace Doan16.Controllers
{
    [Authorize]
    public class HoaDonController : Controller
    {
        // GET: HoaDon
        QLCuaHangDBManage db = new QLCuaHangDBManage();

        public List<HoaDon> Layhoadon()
        {
            var hd = (from s in db.HoaDons
                      orderby s.id_HoaDon descending
                      select s).ToList();
            return hd;
        }
        public ActionResult Index()
        {
            var hd = Layhoadon();
            return View(hd.ToList());
        }

        public ActionResult ChiTietHD(int id)
        {
            HoaDon hoaDon = (from s in db.HoaDons
                             orderby s.id_HoaDon descending
                             where s.id_HoaDon == id
                             select s).SingleOrDefault();

            ViewBag.id_HoaDon = hoaDon.id_HoaDon;
            if (hoaDon == null)
            {
                Response.StatusCode = 404;
            }
            return View(hoaDon);
        }
        [AdminFilters]
        public ActionResult HenHD(int id)
        {
            HoaDon hd = db.HoaDons.Find(id);
            hd.Status = 3;
            db.Entry(hd).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public List<PhieuTraNo> Layphieuno1st()
        {
            var pn = (from s in db.PhieuTraNoes
                      orderby s.id_PhieuTraNo descending
                      select s).Take(1).ToList();
            return pn;
        }
        [AdminFilters]
        public ActionResult NoHD(int id)
        {
            HoaDon hd = db.HoaDons.Find(id);
            hd.Status = 3;
            db.PhieuTraNoes.Add(new PhieuTraNo
            {
                id_HoaDon = id,
                NgayTra = DateTime.Now,
                SoTienTra = (int)hd.TongTien
            });
            db.SaveChanges();
            var pn = Layphieuno1st();
            KhachHang kh = db.KhachHangs.Find(hd.id_KhachHang);
            kh.SoTienConNo -= pn.First().SoTienTra;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [AdminFilters]
        public ActionResult HuyHD(int id)
        {
            HoaDon hd = db.HoaDons.Find(id);
            hd.Status = 4;
            foreach (var ele in hd.ChiTietHoaDons)
            {
                NuocGK nuoc = db.NuocGKs.Find(ele.id_NuocGK);
                nuoc.soluongton += ele.soluongmua;
                db.SaveChanges();
            }
            return View("Index");
        }
    }
}