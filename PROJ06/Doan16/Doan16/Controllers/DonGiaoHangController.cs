using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doan16.Filters;
using Doan16.Models;

namespace Doan16.Controllers
{
    public class DonGiaoHangController : Controller
    {
        QLCuaHangDBManage db = new QLCuaHangDBManage();
        // GET: DonGiaoHang
        

        public List<DonDatHang> dsDonDatHang()
        {
            var ds = (from ddh in db.DonDatHangs
                      orderby ddh.id_DonDatHang descending
                      select ddh).Distinct().ToList();
            return ds;
        }
        public bool CheckReadyDeliveried(List<ChiTietDonDatHang> ds)
        {
            foreach(var item in ds)
            {
                if (item.SoLuongDat != 0)
                    return false;
            }
            return true;
        }
        public List<string> TenNhaCungUng(int id)
        {
            var tenNhaCungUng = (from ddh in db.DonDatHangs
                                 where ddh.id_DonDatHang == id
                                 select ddh.NhaCungUng1.TenNhaCungUng).ToList();
            return tenNhaCungUng ;
        }
        public ActionResult Index(FormCollection collector)
        {
            ViewBag.id_DonDatHang = new SelectList(dsDonDatHang(), "id_DonDatHang", "id_DonDatHang");

            var id = 0;
            ViewBag.Null = false;
            if (collector["id_DonDatHang"] != null)
            {
                id = int.Parse(collector["id_DonDatHang"].ToString());
                var ds = (from ctddh in db.ChiTietDonDatHangs
                          where ctddh.id_DonDatHang == id
                          orderby ctddh.id_DonDatHang descending
                          select ctddh).ToList();
                string tenNhaCungUng = TenNhaCungUng(id).First();
                // kiểm tra đơn đặt hàng đã được giao hết hay chưa
                if (!CheckReadyDeliveried(ds))
                {
                    double total = 0;
                    int quantity = 0;
                    foreach (var item in ds)
                    {
                        double sum = 0;
                        sum += item.NuocGK.dongia - item.NuocGK.dongia * 0.1;
                        quantity += item.SoLuongDat;
                        total += sum;
                    }

                    ViewBag.TongTienDat = total;
                    ViewBag.TongSoLuong = quantity;
                    ViewBag.ID_DDH = id;
                    ViewBag.TenNhaCungUng = tenNhaCungUng;
                    return View(ds);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                ViewBag.Null = true;
                return View();
            }
        }
        public int GetIDpgh()
        {
            var id = (from ds in db.PhieuGiaoHangs
                      orderby ds.id_PhieuGiao descending
                      select ds.id_PhieuGiao).ToList();
            if (id.Count == 0)
                return 1;
            return id[0];
        }
        public ActionResult ThemPhieuGH(FormCollection collector, string[] SLGiao, string[] dongia)
        {
            int idddh = int.Parse(collector["id_dondathang"].ToString());
            double total = 0;

            for(int i = 0; i < SLGiao.Length; i++)
            {
                double gia = double.Parse(dongia[i]) * double.Parse(SLGiao[i]);
                total += gia;
            }

            db.PhieuGiaoHangs.Add(new PhieuGiaoHang
            {
                id_DonDatHang = idddh,
                NgayGiaoHang = DateTime.Now
            });
            db.SaveChanges();

            var ds = (from ddh in db.ChiTietDonDatHangs
                      where ddh.id_DonDatHang == idddh
                      select ddh).ToList();

            int index = 0;
            foreach(var item in ds)
            {
                db.ChiTietPhieuGiaoHangs.Add(new ChiTietPhieuGiaoHang
                {
                    id_PhieuGiao = GetIDpgh(),
                    id_NuocGK = item.id_NuocGK,
                    SoLuongGiao = int.Parse(SLGiao[index]),
                    DonGiaGiao = int.Parse(dongia[index])
                });
                index++;
                db.SaveChanges();
            }

            ViewBag.TongTienGiao = total;
            ViewBag.HienThi = idddh;
            return View();
        }
        public ActionResult ChiTietPhieuGiaoHang()
        {
            return View();
        }

    }
}