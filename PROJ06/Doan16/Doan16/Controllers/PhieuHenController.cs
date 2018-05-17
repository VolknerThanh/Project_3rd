using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doan16.Models;

namespace Doan16.Controllers
{
    [Authorize]
    public class PhieuHenController : Controller
    {
        // GET: PhieuHen
        QLCuaHangDBManage db = new QLCuaHangDBManage();
        public List<PhieuHen> Layphieuhen()
        {
            var ph = (from s in db.PhieuHens
                      orderby s.id_PhieuHen descending
                      select s).ToList();
            return ph;
        }
        public ActionResult Index()
        {
            var ph = Layphieuhen();
            return View(ph.ToList());
        }
        public ActionResult ChiTietPH(int id)
        {
            PhieuHen phieuhen = (from s in db.PhieuHens
                                 orderby s.id_PhieuHen descending
                                 where s.id_PhieuHen == id
                                 select s).SingleOrDefault();

            ViewBag.id_PhieuHen = phieuhen.id_PhieuHen;
            if (phieuhen == null)
            {
                Response.StatusCode = 404;
            }
            return View(phieuhen);
        }
    }
}