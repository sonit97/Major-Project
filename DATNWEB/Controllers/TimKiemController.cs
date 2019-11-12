using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace DATNWEB.Controllers
{
    public class TimKiemController : Controller
    {
        LaptopShopDbContext db = new LaptopShopDbContext();
        // GET: TimKiem
        [HttpGet]
        public ActionResult KQTimKiem(string sTuKhoa,int? page)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int PageSize = 5;
            int PageNumber = (page ?? 1);
            var list = db.SanPhams.Where(n => n.TenSP.Contains(sTuKhoa)|| n.NhaSanXuat.TenNSX.Contains(sTuKhoa));
            ViewBag.TuKhoa = sTuKhoa;
            
            return View(list.OrderBy(n=>n.TenSP).ToPagedList(PageNumber,PageSize));
        }

        [HttpPost]
        public ActionResult KeyTimKiem(string sTuKhoa)
        {
            return RedirectToAction("KQTimKiem",new { @sTuKhoa = sTuKhoa });
        }
    }
}