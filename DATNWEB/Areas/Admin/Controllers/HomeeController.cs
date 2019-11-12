using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATNWEB.Areas.Admin.Controllers
{
    public class HomeeController : BaseController
    {
        LaptopShopDbContext db = new LaptopShopDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.DonHangDoiDuyet = db.DonDatHangs.Count(n => n.TinhTrang == 0);
            ViewBag.SoNguoiTruyCap = HttpContext.Application["SoNguoiTruyCap"].ToString();
            ViewBag.SoNguoiDangOnline = HttpContext.Application["SoNguoiDangOnline"].ToString();
            ViewBag.DonHangGiao = db.DonDatHangs.Count(n => n.TinhTrangGH == 0);

            ViewBag.TongDoanhThu = ThongKeTongDoanhThu();
            return View();
        }

        //public decimal ThongKeDoanhThuThang(int Thang,int Nam)
        //{
        //    decimal TongDanhThuThangNam = db.DonDatHangs.Where(x=>x.NgayDat.Value.Month==Thang && x.NgayDat.Value.Year==Nam).Sum(n => n.TongTien).Value;
        //    return TongDanhThuThangNam;
        //}

        public decimal ThongKeTongDoanhThu()
        {
            decimal TongDanhThu =db.DonDatHangs.Sum(n => n.TongTien).Value;
            return TongDanhThu;
        }
      
    }
}