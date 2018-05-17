using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doan16.Models;

namespace Doan16.Controllers
{
    [Authorize]
    public class DonDatHangController : Controller
    {
        QLCuaHangDBManage db = new QLCuaHangDBManage();
        // GET: DonDatHang
        public List<DonDatHang> Laydondathang()
        {
            var ddh = (from s in db.DonDatHangs
                       orderby s.id_DonDatHang descending
                       select s).ToList();
            return ddh;
        }
        public ActionResult Index()
        {
            var ddh = Laydondathang();
            return View(ddh.ToList());
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

        public ActionResult dathang()
        {
            return View();
        }
        //public ActionResult SuaDDH(int id)
    }
}