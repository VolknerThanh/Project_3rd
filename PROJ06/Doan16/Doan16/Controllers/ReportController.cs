using Doan16.Report;
using Doan16.Report.DataSetDoanhSoTableAdapters;
using Doan16.Report.DataSetSoLuongTonTableAdapters;
using Microsoft.Reporting.WebForms;
using System;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Doan16.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Report()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Report(FormCollection col)
        {
            try
            {
                DateTime date1 = Convert.ToDateTime(col["dt1"].ToString());
                DateTime date2 = Convert.ToDateTime(col["dt2"].ToString());
                int Status = int.Parse(col["stt"].ToString());
                return RedirectToAction("ReportDoanhSo", new { dt1 = date1, dt2 = date2, stt = Status });
            }
            catch (FormatException)
            {
                ModelState.AddModelError("ErrorMessage", "Vui lòng nhập đúng định dạng dd/MM/yyyy");
                return View();
            }
            catch (Exception)
            {
                ModelState.AddModelError("ErrorMessage", "Vui lòng nhập đúng định dạng dd/MM/yyyy");
            }
            return View();
        }

        public ActionResult ReportDoanhSo(DateTime dt1, DateTime dt2, int stt)
        {
            SetLocalReport(dt1, dt2, stt);
            return View();
        }

        private void SetLocalReport(DateTime dt1, DateTime dt2, int stt)
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(500);
            reportViewer.Height = Unit.Percentage(500);
            reportViewer.ShowPrintButton = true;

            DataSetDoanhSo doanhSoDataSet = new DataSetDoanhSo();
            HoaDonTableAdapter hoaDonTableAdapter = new HoaDonTableAdapter();
            hoaDonTableAdapter.Fill(doanhSoDataSet.HoaDon, dt1.ToString(), dt2.ToString(), stt);

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Report\BaoCaoDoanhSo.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetDoanhSo", doanhSoDataSet.Tables[0]));

            ViewBag.ReportViewer = reportViewer;
        }
        public ActionResult ReportSoLuong()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReportSoLuong(FormCollection col)
        {
            try
            {
                int Soluong = int.Parse(col["soluong"].ToString());
                return RedirectToAction("ReportSoluongton", new { soluong = Soluong });
            }
            catch (FormatException)
            {
                ModelState.AddModelError("ErrorMessage", "Vui lòng nhập số nguyên");
                return View();
            }
            catch (Exception)
            {
                ModelState.AddModelError("ErrorMessage", "Vui lòng nhập số nguyên");
            }
            return View();
        }

        public ActionResult ReportSoluongton(int soluong)
        {
            SetLocalReportSL(soluong);
            return View();
        }

        private void SetLocalReportSL(int soluong)
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(500);
            reportViewer.Height = Unit.Percentage(500);
            reportViewer.ShowPrintButton = true;

            DataSetSoLuongTon soLuongTonDataSet = new DataSetSoLuongTon();
            NuocGKTableAdapter nuocGKTableAdapter = new NuocGKTableAdapter();
            nuocGKTableAdapter.Fill(soLuongTonDataSet.NuocGK, soluong);

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Report\BaoCaoSoLuongTon.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetSoLuongTon", soLuongTonDataSet.Tables[0]));

            ViewBag.ReportViewer = reportViewer;
        }
    }
}