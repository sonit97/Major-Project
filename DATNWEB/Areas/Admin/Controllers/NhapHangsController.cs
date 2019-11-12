using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATNWEB.Areas.Admin.Controllers
{
    public class NhapHangsController : BaseController
    {
        LaptopShopDbContext db = new LaptopShopDbContext();
        // GET: Admin/NhapHangs
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NhapHang()
        {
            ViewBag.MaNCC = db.NhaCungCaps;
            ViewBag.ListSanPham = db.SanPhams;
            return View();
        }
        [HttpPost]
        public ActionResult NhapHang(PhieuNhap model,IEnumerable<ChiTietPhieuNhapp> ListModel)
        {
            ViewBag.MaNCC = db.NhaCungCaps;
            ViewBag.ListSanPham = db.SanPhams;
            db.PhieuNhaps.Add(model);
            db.SaveChanges();
            foreach (var item in ListModel)
            {
                item.MaPN = model.MaPN;
            }
            db.ChiTietPhieuNhapps.AddRange(ListModel);
            db.SaveChanges();
            return View();
        }
    }
}