using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doan16.Models;

namespace Doan16.Controllers
{
    public class PhieuNoController : Controller
    {
        QLCuaHangDBManage db = new QLCuaHangDBManage();
        public List<PhieuTraNo> Layphieuno()
        {
            var pn = (from s in db.PhieuTraNoes
                      orderby s.id_PhieuTraNo descending
                      select s).ToList();
            return pn;
        }
        // GET: PhieuNo
        public ActionResult Index()
        {
            var pn = Layphieuno();
            return View(pn.ToList());
        }
    }
}