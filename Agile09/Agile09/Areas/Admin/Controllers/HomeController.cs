using Agile09.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agile09.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            DateTime day = DateTime.Now;
            var dayCurentOneMonth = day.AddMonths(-1);
            ViewBag.day = day.ToString(string.Format("yyyy-MM-dd"));
            ViewBag.dayCurentOneMonth = dayCurentOneMonth.ToString(string.Format("yyyy-MM-dd"));
            return View();
        }
        //Admin/Home/ThongKe
        [HttpPost]
        public ActionResult ThongKe(DateTime? fromDate, DateTime? toDate)
        {
            var model = new OrderDAO();
            var result = model.ListAll(fromDate, toDate);
            if (fromDate.HasValue)
            {
                result = result.Where(hh => hh.Ngay >= fromDate.Value);
            }
            if (toDate.HasValue)
            {
                result = result.Where(hh => hh.Ngay <= toDate.Value);
            }
            var format = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            var data = result.Select(tk => new
            {
                Ngay = tk.Ngay.ToString(string.Format("dd/MM/yyyy")),
                TongGiaBan = tk.TongGiaBan,
                DoanhThu = tk.DoanhThu,
                Tong = String.Format(format, "{0:c0}", tk.TongGiaBan),
                LoiNhuan = String.Format(format, "{0:c0}", tk.DoanhThu),
            });
            return Json(data);
        }
        //Admin/Home/ThongKeSanPham
        [HttpPost]
        public ActionResult ThongKeSanPham(DateTime? fromDate, DateTime? toDate)
        {
            var model = new OrderDAO();
            var resultSP = model.ThongKeSP(fromDate, toDate);
            if (fromDate.HasValue)
            {
                resultSP = resultSP.Where(hh => hh.Ngay >= fromDate.Value);
            }
            if (toDate.HasValue)
            {
                resultSP = resultSP.Where(hh => hh.Ngay <= toDate.Value);
            }
            var format = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            var dataSP = resultSP.Select(tk => new
            {
                Ngay = tk.Ngay.ToString(string.Format("dd/MM/yyyy")),
                TongGiaBan = String.Format(format, "{0:c0}", tk.TongGiaBan),
                Name = tk.Name,
                Quantity = tk.Quantity,
                Price = String.Format(format, "{0:c0}", tk.Price),
                TongDoanhThu = tk.TongGiaBan
            });
            return Json(dataSP);
        }
    }
}