﻿using System;
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
            if (Session["LoaiTaiKhoan"] != null && bool.Parse(Session["LoaiTaiKhoan"].ToString()) == true)
            {
                if (name != null && name != "")
                    return (from n in db.NuocGKs
                            where n.tenNGK.ToUpper().Contains(name.ToUpper())
                            orderby n.id_NuocGK descending
                            select n).Take(count).ToList();
                else
                    return (from n in db.NuocGKs
                            orderby n.id_NuocGK descending
                            select n).Take(count).ToList();
            }
            else
            {
                if (name != null && name != "")
                    return (from n in db.NuocGKs
                            where n.tenNGK.ToUpper().Contains(name.ToUpper()) && n.soluongton > 0
                            orderby n.id_NuocGK descending
                            select n).Take(count).ToList();
                else
                    return (from n in db.NuocGKs
                            where n.soluongton > 0
                            orderby n.id_NuocGK descending
                            select n).Take(count).ToList();
            }

            /*
            if(name != null && name != "")
                return (from n in db.NuocGKs
                        where n.tenNGK.ToUpper().Contains(name.ToUpper())
                        orderby n.id_NuocGK descending
                        select n).Take(count).ToList();
            else
                return (from n in db.NuocGKs
                        orderby n.id_NuocGK descending
                        select n).Take(count).ToList();
            */
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

        public ActionResult NhaCungUng()
        {
            var nhacungung = from ncu in db.NhaCungUngs select ncu;
            return PartialView(nhacungung);
        }

        public ActionResult LoaiNGK()
        {
            var loaingk = from lngk in db.LoaiNGKs select lngk;
            return PartialView(loaingk);
        }
        public ActionResult SPTheoNhaCungUng(int id)
        {
            if (Session["LoaiTaiKhoan"] != null && bool.Parse(Session["LoaiTaiKhoan"].ToString()) == true)
            {
                var ncu = from s in db.NuocGKs where s.LoaiNGK.NhaCungUng1.id_NhaCungUng == id select s;
                ViewBag.SoLuongTheoNCU = ncu.Count();
                return View(ncu);
            }
            else
            {
                var ncu = from s in db.NuocGKs where s.LoaiNGK.NhaCungUng1.id_NhaCungUng == id && s.soluongton > 0 select s;
                ViewBag.SoLuongTheoNCU = ncu.Count();
                return View(ncu);
            }
        }

        public ActionResult SPTheoLoaiNGK(int id)
        {
            if (Session["LoaiTaiKhoan"] != null && bool.Parse(Session["LoaiTaiKhoan"].ToString()) == true)
            {
                var lngk = from s in db.NuocGKs where s.LoaiNGK.id_LoaiNGK == id select s;
                ViewBag.SoLuongTheoLoai = lngk.Count();
                return View(lngk);
            }
            else
            {
                var lngk = from s in db.NuocGKs where s.LoaiNGK.id_LoaiNGK == id && s.soluongton > 0 select s;
                ViewBag.SoLuongTheoLoai = lngk.Count();
                return View(lngk);
            }
        }

        public ActionResult SanPhamLon()
        {
            // nuoc co ga
            /*
            var name = "Lon";
            var item = from sp_lon in db.NuocGKs
                       where sp_lon.tenNGK.ToUpper().Contains(name.ToUpper())
                       orderby sp_lon.id_NuocGK descending
                       select sp_lon;
            */
            if (Session["LoaiTaiKhoan"] != null && bool.Parse(Session["LoaiTaiKhoan"].ToString()) == true)
            {
                var item = from sp in db.NuocGKs
                       where sp.LoaiNGK.id_LoaiNGK == 1
                       orderby sp.id_NuocGK descending
                       select sp;

                return PartialView(item.Take(4).ToList());
            }
            else
            {
                var item = from sp in db.NuocGKs
                           where sp.LoaiNGK.id_LoaiNGK == 1 && sp.soluongton > 0
                           orderby sp.id_NuocGK descending
                           select sp;

                return PartialView(item.Take(4).ToList());
            }

        }
        public ActionResult SanPhamChai()
        {
            /*
            var name = "Chai";
            var item = from sp_chai in db.NuocGKs
                       where sp_chai.tenNGK.ToUpper().Contains(name.Trim().ToUpper())
                       orderby sp_chai.id_NuocGK descending
                       select sp_chai;
            */
            // nuoc suoi
            if (Session["LoaiTaiKhoan"] != null && bool.Parse(Session["LoaiTaiKhoan"].ToString()) == true)
            {
                var item = from sp in db.NuocGKs
                           where sp.LoaiNGK.id_LoaiNGK == 2
                           orderby sp.id_NuocGK descending
                           select sp;

                return PartialView(item.Take(4).ToList());
            }
            else
            {
                var item = from sp in db.NuocGKs
                           where sp.LoaiNGK.id_LoaiNGK == 2 && sp.soluongton > 0
                           orderby sp.id_NuocGK descending
                           select sp;

                return PartialView(item.Take(4).ToList());
            }

        }
        public ActionResult SanPhamNuocSuoi()
        {
            /*
            var sanpham = from sp in db.NuocGKs
                          where !(sp.tenNGK.ToUpper().Contains("chai".Trim().ToUpper()) || sp.tenNGK.ToUpper().Contains("lon".Trim().ToUpper()))
                          orderby sp.id_NuocGK descending
                          select sp;
            */
            // nuoc tang luc
            
            if (Session["LoaiTaiKhoan"] != null && bool.Parse(Session["LoaiTaiKhoan"].ToString()) == true)
            {
                var item = from sp in db.NuocGKs
                           where sp.LoaiNGK.id_LoaiNGK == 3
                           orderby sp.id_NuocGK descending
                           select sp;
                return PartialView(item.Take(4).ToList());
            }
            else
            {
                var item = from sp in db.NuocGKs
                           where sp.LoaiNGK.id_LoaiNGK == 3 && sp.soluongton > 0
                           orderby sp.id_NuocGK descending
                           select sp;
                return PartialView(item.Take(4).ToList());
            }
        }
        public ActionResult SanPhamConLai()
        {
            if (Session["LoaiTaiKhoan"] != null && bool.Parse(Session["LoaiTaiKhoan"].ToString()) == true)
            {
                var item = from sp in db.NuocGKs
                           where sp.LoaiNGK.id_LoaiNGK != 1 && sp.LoaiNGK.id_LoaiNGK != 2 && sp.LoaiNGK.id_LoaiNGK != 3
                           orderby sp.id_NuocGK descending
                           select sp;
                return PartialView(item.Take(2).ToList());
            }
            else
            {
                var item = from sp in db.NuocGKs
                           where sp.LoaiNGK.id_LoaiNGK != 1 && sp.LoaiNGK.id_LoaiNGK != 2 && sp.LoaiNGK.id_LoaiNGK != 3 && sp.soluongton > 0
                           orderby sp.id_NuocGK descending
                           select sp;
                return PartialView(item.Take(2).ToList());
            }
        }
        public ActionResult Details(int id)
        {
            var item = from ngk in db.NuocGKs
                       where ngk.id_NuocGK == id
                       select ngk;
            return View(item.Single());
        }
        public ActionResult SumProduct()
        {
            int sum = 0;                
            if (Session["LoaiTaiKhoan"] != null && bool.Parse(Session["LoaiTaiKhoan"].ToString()) == true)
            {
                var items = (from sp in db.NuocGKs
                            select sp).ToList();
                sum = items.Count;
            }
            else
            {
                var items = (from sp in db.NuocGKs
                            where sp.soluongton > 0
                            select sp).ToList();
                sum = items.Count;
            }
            return PartialView(sum);
        }
    }
}