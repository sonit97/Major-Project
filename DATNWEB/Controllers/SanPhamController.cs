using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Model.DAO;

namespace DATNWEB.Controllers
{
    public class SanPhamController : Controller
    {
        LaptopShopDbContext db = new LaptopShopDbContext();
        //Tạo 2 partial view sản phẩm 1 và 2 để hiển thị sản phẩm.
        [ChildActionOnly]
        public ActionResult SanPhamstyle1Partial()
        {

            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult SanPhamstyle2Partial()
        {

            return PartialView();
        }
      
        public ActionResult XemChiTiet(int? id,string tensp)
        {
            //kiểm ta tham so truyen vao trống hay không.
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                 
            }
            //nếu không thể truy xuất csdl lấy ra sản phẩm tương ứng.
            SanPham sp = db.SanPhams.SingleOrDefault(n=>n.MaSP==id );
            if(sp==null)
            {
                //Thông báo khi không có sản phẩm đó.
                return HttpNotFound();
            }
             
            return View(sp);
        }
        public ActionResult SanPham(int? MaLoaiSP,int? MaNSX,int? page)
        {
            if (MaLoaiSP==null || MaNSX==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /* lấy sản phẩm dựa theo  mã sản phâm và mã nhà sx */
            var lstSP = db.SanPhams.Where(n=>n.MaLoaiSP==MaLoaiSP && n.MaNSX==MaNSX);
            if (lstSP.Count() == 0)
            {
                //Thông báo nếu như không có sản phẩm đó
                return HttpNotFound();
            }
            int PageSize = 3;
            int PageNumber = (page ?? 1);

            return View(lstSP.OrderBy(n=>n.MaSP).ToPagedList(PageNumber, PageSize));
        }

        public JsonResult ListName(string q)
        {
            var data = new SanPhamDAO().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        //
        //public ActionResult Search(string keyword, int page=1)
        //{
        //    int totalRecord = 0;
        //    var model = new SanPhamDAO().Search(keyword, ref totalRecord);

        //    ViewBag.Total = totalRecord;
        //    ViewBag.Page = page;
        //    ViewBag.Keyword = keyword;

        //    return View(model);
        //}

    }
}