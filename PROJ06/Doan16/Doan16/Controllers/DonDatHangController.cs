using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doan16.Filters;
using Doan16.Models;

namespace Doan16.Controllers
{
    [Authorize]
    [AdminFilters]
    public class DonDatHangController : Controller
    {
        QLCuaHangDBManage db = new QLCuaHangDBManage();
        // GET: DonDatHang
        public List<NuocGK> OutOfStockList()
        {
            // xuat cac san pham co so luong ton <= 0 (het hang)
            var items = (from s in db.NuocGKs
                         where s.soluongton <= 10
                         orderby s.id_NuocGK descending
                         select s).ToList();
            return items;
        }
        public List<NuocGK> OutOfStockListWithID(int id)
        {
            // xuat cac san pham co so luong ton <= 0 (het hang)
            var items = (from s in db.NuocGKs
                         where s.soluongton <= 10 && s.LoaiNGK.NhaCungUng1.id_NhaCungUng == id
                         orderby s.id_NuocGK descending
                         select s).ToList();
            return items;
        }
        public List<string> DsNCU()
        {
            var ds = (from s in db.NuocGKs
                      where s.soluongton <= 10
                      orderby s.LoaiNGK.NhaCungUng1.id_NhaCungUng descending
                      select s.LoaiNGK.NhaCungUng1.TenNhaCungUng).ToList();

            return ds;
        }
        public List<NhaCungUng> Ds()
        {
            var ds = (from ngk in db.NuocGKs
                      where ngk.soluongton <= 10
                      orderby ngk.id_NuocGK descending
                      select ngk.LoaiNGK.NhaCungUng1).Distinct().ToList();
            return ds;
        }
        public ActionResult Index()
        {
            ViewBag.id_NhaCungUng = new SelectList(Ds().ToList(), "id_NhaCungUng", "TenNhaCungUng");
            var spHetHang = OutOfStockList();
            var dsNCU = Ds();
            Tuple<List<NuocGK>, List<NhaCungUng>> ds = new Tuple<List<NuocGK>, List<NhaCungUng>>(spHetHang, dsNCU);
            return View(ds);
        }
        public ActionResult ChiTietDDH(int id)
        {
            DonDatHang ddh = (from s in db.DonDatHangs
                              orderby s.id_DonDatHang descending
                              where s.id_DonDatHang == id
                              select s).SingleOrDefault();

            ViewBag.id_DonDatHang = ddh.id_DonDatHang;
            if (ddh == null)
            {
                Response.StatusCode = 404;
            }
            return View(ddh);
        }

        public List<NuocGK> layLNGKSoluongAm()
        {
            var lngk = (from s in db.NuocGKs
                        orderby s.nhanhieuNGK
                        where s.soluongton <= 0
                        select s).ToList();
            return lngk;
        }
        public int GetIdDDH()
        {
            var id = (from s in db.DonDatHangs
                      orderby s.id_DonDatHang descending
                      select s.id_DonDatHang).ToList();

            if (id.Count == 0)
                return 1;
            return id[0];
        }
        public ActionResult AddToDDH(FormCollection collector)
        {
            if (collector["id_NhaCungUng"] == null)
                return RedirectToAction("Index");
            
            int idNCU = int.Parse(collector["id_NhaCungUng"].ToString());
            
            // luu vao don dat hang
            db.DonDatHangs.Add(new DonDatHang
            {
                NhaCungUng = idNCU,
                NgayDatHang = DateTime.Now
            });
            db.SaveChanges();
            var lsthang = OutOfStockListWithID(idNCU);
            foreach (var item in lsthang)
            {
                db.ChiTietDonDatHangs.Add(new ChiTietDonDatHang
                {
                    id_DonDatHang = GetIdDDH(),
                    id_NuocGK = item.id_NuocGK,
                    SoLuongDat = item.soluongton * -1 + 20
                });
                db.SaveChanges();
            }

            return RedirectToAction("DonDatHang", "DonDatHang");
        }
        public ActionResult XoaDDH(int id)
        {
            var ctddh = (from a in db.ChiTietDonDatHangs
                         where a.id_DonDatHang == id
                         select a).ToList();

            if (ctddh != null)
                ctddh.RemoveAll(n => n.id_DonDatHang == id);

            DonDatHang ddh = db.DonDatHangs.SingleOrDefault(n => n.id_DonDatHang == id);

            if (ddh != null)
                db.DonDatHangs.Remove(ddh);

            db.SaveChanges();

            return RedirectToAction("DonDatHang", "DonDatHang");
        }
        public ActionResult UpdateSLD(int idDon, int idNGk, FormCollection collector)
        {
            var soluongDAT = int.Parse(collector["SLD"].ToString());

            ChiTietDonDatHang ctddh = db.ChiTietDonDatHangs.Single(n => n.id_DonDatHang == idDon && n.id_NuocGK == idNGk);
            ctddh.SoLuongDat = soluongDAT;
            db.SaveChanges();

            return RedirectToAction("ChiTietDDH", "DonDatHang", new { id = idDon });
        }
        public ActionResult XoaCTDDH(int idDon, int idNGk)
        {
            ChiTietDonDatHang ctddh = db.ChiTietDonDatHangs.Single(n => n.id_DonDatHang == idDon && n.id_NuocGK == idNGk);
            db.ChiTietDonDatHangs.Remove(ctddh);
            db.SaveChanges();
            
            return RedirectToAction("ChiTietDDH", "DonDatHang", new { id = idDon });
        }
        public List<DonDatHang> laydondathang()
        {
            var ddh = (from s in db.DonDatHangs
                       orderby s.id_DonDatHang descending
                       select s).ToList();
            return ddh;
        }
        public ActionResult DonDatHang()
        {
            var ddh = laydondathang();
            return View(ddh.ToList());
        }
    }
}