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
                double sum = 0;
                int quantity = 0;
                foreach(var item in ds)
                {
                    sum += item.NuocGK.dongia;
                    quantity += item.SoLuongDat;
                }

                ViewBag.TongTienDat = sum - sum * 0.1;
                ViewBag.ID_DDH = id;
                return View(ds);
            }
            else
            {
                ViewBag.Null = true;
                return View();
            }
        }
        public ActionResult ChiTietPhieuGiaoHang()
        {
            return View();
        }

    }
}