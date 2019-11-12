using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;
namespace DATNWEB.Controllers
{
    public class HomeController : Controller
    {
        LaptopShopDbContext db = new LaptopShopDbContext();
        // GET: Home
        public ActionResult Index()
        {
            //Laand lượt tạo các viewbag để lấy list sản phẩm từ csdl
            //List dt apple
            var listdtm = db.SanPhams.Where(n => n.MaLoaiSP == 1 && n.MaNSX == 2 );
            //gán vào viewbag
            ViewBag.ListDTM = listdtm;
            //List huawei
            var listtablet = db.SanPhams.Where(n => n.MaLoaiSP == 1  && n.MaNSX == 11);
            //gán vào viewbag
            ViewBag.ListTBM = listtablet;

            //List OPPO
            var listltm = db.SanPhams.Where(n => n.MaLoaiSP == 1 && n.MaNSX == 6);
            //gán vào viewbag
            ViewBag.ListLTM = listltm;

            return View();
        }
        public ActionResult MenuPartial()
        {
            ///truy vấn lấy về 1 list các sp
            var listsp = db.SanPhams;
            return PartialView(listsp);
        }
        public ActionResult MenuLeft()
        {
            ///truy vấn lấy về 1 list các sp
            var listsp = db.SanPhams;
            return PartialView(listsp);
        }
        public ActionResult Footer()
        {
            ViewBag.SoNguoiTruyCap = HttpContext.Application["SoNguoiTruyCap"].ToString();
            ViewBag.SoNguoiDangOnline = HttpContext.Application["SoNguoiDangOnline"].ToString();
            return PartialView();
        }
        [HttpGet]
        public ActionResult DangKy()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DangKy(ThanhVien tv,FormCollection f)
        {
            //Kiểm tra captcha hợp lệ
            if (this.IsCaptchaValid("Captcha is not valid"))
            {
                if (ModelState.IsValid) {
                    ViewBag.ThongBao = "Đăng ký thành công";
                   
                    //Thêm khách hàng vào csdl
                    db.ThanhViens.Add(tv);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.ThongBao = "Đăng ký thất bại";
                }
            
                return View();
            }
            ViewBag.ThongBao = "Sai captcha";
            return View();
        }

    //Tạo action đăng nhập
         [HttpPost]
         public ActionResult DangNhap(FormCollection f)
         {
            //kiểm tra tên đăng nhập và MK
            string sTaiKhoan = f["txtTenDangNhap"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();
            ThanhVien tv = db.ThanhViens.SingleOrDefault(n=>n.TaiKhoan==sTaiKhoan && n.MatKhau==sMatKhau);
            if (tv != null)
            {
                Session["TaiKhoan"] = tv;
                //return RedirectToAction("Index");
               return Content("<script>window.location.reload();</script>");

            }
            return Content("Tài khoản hoặc mật khẩu không đúng!!!");
         }
       
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index");
        }
    }
}