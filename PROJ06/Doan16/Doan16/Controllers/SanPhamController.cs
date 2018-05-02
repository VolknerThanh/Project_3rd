using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doan16.Models;
using PagedList;
using PagedList.Mvc;

namespace Doan16.Controllers
{
    public class SanPhamController : Controller
    {
        QLCuaHangDBManage db = new QLCuaHangDBManage();
        // GET: TrangChu
        public List<NuocGK> Layngkmoi(int count, string name)
        {
            if(name!=null && name!= "")
            {
                return (from n in db.NuocGKs where n.tenNGK.ToUpper().Contains(name.ToUpper()) orderby n.id_NuocGK descending select n).Take(count).ToList();
            }
            else
                return (from n in db.NuocGKs orderby n.id_NuocGK descending select n).Take(count).ToList();
        }
        public ActionResult Index(int ? page, FormCollection fc)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);
            string name = fc["SearchString"];
            var nuocgkmoi = Layngkmoi(20, name);
            return View(nuocgkmoi.ToPagedList(pageNum, pageSize));
        }

        public ActionResult TimKiem()
        {
            return PartialView();
        }


    }
}