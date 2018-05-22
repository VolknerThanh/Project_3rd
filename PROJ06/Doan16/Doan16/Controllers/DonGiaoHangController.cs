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
            // lọc danh sách đơn đặt hàng có chi tiết đặt hàng có số lượng bằng 0
            foreach(var item in ds.ToList())
            {
                var ctddh = (from ct in db.ChiTietDonDatHangs
                             where ct.id_DonDatHang == item.id_DonDatHang
                             select ct).ToList();
                if (CheckReadyDeliveried(ctddh))
                    ds.Remove(item);
            }

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
        public ActionResult ThemPhieuGH(FormCollection collector, string[] SLGiao, string[] SLDat, string[] dongia, string[] idsp)
        {
            int idddh = int.Parse(collector["id_dondathang"].ToString());
            double total = 0;

            for(int i = 0; i < SLGiao.Length; i++)
            {
                double gia = double.Parse(dongia[i]) * double.Parse(SLGiao[i]);
                total += gia;
            }

            #region luu vao phieu giao hang
            db.PhieuGiaoHangs.Add(new PhieuGiaoHang
            {
                id_DonDatHang = idddh,
                NgayGiaoHang = DateTime.Now
            });
            db.SaveChanges();
            #endregion
       
            #region luu vao chi tiet phieu giao hang
            // kiểm tra số đợt giao hàng
            var danhsach = (from ddh in db.PhieuGiaoHangs
                      where ddh.id_DonDatHang == idddh
                      select ddh).ToList();

            var ds = (from ddh in db.ChiTietDonDatHangs
                        where ddh.id_DonDatHang == idddh
                        select ddh).ToList();
            int index = 0;
            
            // nếu còn 1 đợt thì PHẢI GIAO HẾT
            if (danhsach.Count > 2)
            {
                //chỉ còn 1 đợt
                foreach (var item in ds)
                {
                    db.ChiTietPhieuGiaoHangs.Add(new ChiTietPhieuGiaoHang
                    {
                        id_PhieuGiao = GetIDpgh(),
                        id_NuocGK = item.id_NuocGK,
                        SoLuongGiao = int.Parse(SLDat[index]), // gan so luong giao = so luong dat con lai
                        DonGiaGiao = int.Parse(dongia[index])
                    });
                    index++;
                    db.SaveChanges();
                }
            }
            else
            {
                foreach (var item in ds)
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
            }
            //---
            #endregion

            #region cap nhat so luong dat trong chi tiet dat hang
            var donHang = (from ddh in db.ChiTietDonDatHangs
                           where ddh.id_DonDatHang == idddh
                           select ddh).ToList();
            int index_1 = 0;
            if (danhsach.Count > 2)
            {
                foreach (var item in donHang)
                {
                    item.SoLuongDat -= int.Parse(SLDat[index_1]);
                    index_1++;
                }
            }
            else
            {
                foreach(var item in donHang)
                {
                    item.SoLuongDat -= int.Parse(SLGiao[index_1]);
                    index_1++;
                }
            }
            db.SaveChanges();
            #endregion

            #region luu vao so luong ton trong kho
            var khoHang = (from kho in db.NuocGKs
                           orderby kho.id_NuocGK ascending // tang dan
                           select kho).ToList();
            int index_2 = 0;
            if(danhsach.Count > 2)
            {
                foreach (var item in khoHang)
                {
                    if (item.id_NuocGK == int.Parse(idsp[index_2]))
                    {
                        item.soluongton += int.Parse(SLDat[index_2]);
                        index_2++;
                        if (index_2 >= idsp.Length) break; // pause khi du so luong
                    }
                }
            }
            else
            {

                foreach(var item in khoHang)
                {
                    if(item.id_NuocGK == int.Parse(idsp[index_2]))
                    {
                        item.soluongton += int.Parse(SLGiao[index_2]);
                        index_2++;
                        if (index_2 >= idsp.Length) break; // pause khi du so luong
                    }
                }
            }
            db.SaveChanges();
            #endregion

            ViewBag.TongTienGiao = total;
            ViewBag.HienThi = idddh;
            return View();
        }
        public ActionResult DanhSach()
        {
            var ds = (from pgh in db.PhieuGiaoHangs
                      orderby pgh.id_PhieuGiao descending
                      select pgh).ToList();
            return View(ds);
        }
        public int TongSoLuong(List<ChiTietPhieuGiaoHang> ds)
        {
            int sum = 0;
            foreach(var item in ds)
            {
                sum += item.SoLuongGiao;
            }
            return sum;
        }
        public double TongThanhTien(List<ChiTietPhieuGiaoHang> ds)
        {
            double total = 0;
            foreach(var item in ds)
            {
                total += item.DonGiaGiao * item.SoLuongGiao;
            }
            return total;
        }
        public ActionResult ChiTietPhieuGiaoHang(int idDGH)
        {
            var ds = (from a in db.ChiTietPhieuGiaoHangs
                      where a.id_PhieuGiao == idDGH
                      orderby a.id_PhieuGiao descending
                      select a).ToList();
            ViewBag.ID_giaoHang = idDGH;
            ViewBag.TongSoLuong = TongSoLuong(ds);
            ViewBag.TongThanhTien = TongThanhTien(ds);
            return View(ds);
        }

    }
}