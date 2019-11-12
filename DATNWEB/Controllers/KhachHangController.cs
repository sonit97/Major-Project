using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATNWEB.Controllers
{
    public class KhachHangController : Controller
    {
        LaptopShopDbContext db = new LaptopShopDbContext();
        // GET: Index
        public ActionResult Index()
        {
            if (Session["TaiKhoan"] != null)
            {
                ThanhVien tv = Session["TaiKhoan"] as ThanhVien;
                ViewBag.TV = tv;
            }
            return View();
        }   
        [HttpGet]
        public ActionResult ChinhSua()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChinhSua(ThanhVien tvien)
        {
            ThanhVien tvv = Session["TaiKhoan"] as ThanhVien;
            var tv = db.ThanhViens.Find(tvien.MaThanhVien);
            if (tv != null)
            {
                tv.Hoten = tvien.Hoten;
                tv.TaiKhoan = tvv.TaiKhoan;
                tv.MatKhau = tvien.MatKhau;             
                tv.DiaChi = tvien.DiaChi;
                tv.SoDienThoai = tvien.SoDienThoai;
                db.SaveChanges();
                ViewBag.TV = tv;
                RedirectToAction("Index", "User");
            }
            else
            {               
                    ModelState.AddModelError("", "Sửa thành công");                
            }           
            return View("Index");
        }
        [HttpGet]
        public ActionResult XemDonHang(int mathanhvien,int ma)
        {
            DonDatHangDAO ddh = null;
            if (ma != 0)
            {
                ddh = new DonDatHangDAO();
                ChangeStatus(ma);
                List<DonDatHangDAO> list = ddh.getlist(mathanhvien);
                return View(list);
            }
            else
            {
                ddh = new DonDatHangDAO();
                //ChangeStatus(36);
                List<DonDatHangDAO> list = ddh.getlist(mathanhvien);
                return View(list);
            }
            // var tv = db.KhachHangs.Find(mathanhvien);
            //  var donhang = db.DonDatHangs.Where(n=>n.MaKH==tv.MaKH);
            // var list = db.KhachHangs.Where(n=>n.MaKH==n.MaKH && n.MaThanhVien==mathanhvien);
            //var list = db.ThanhViens;
            //var listdh = db.DonDatHangs.Where(n=>n.MaKH==list.);
            //var dao = new DonDatHangDAO();
            //var pg = dao.Listallpaging(donhang.MaKH);
            //  ViewBag.ListDH = list;                    
        }
        //huy don hang
        //[HttpPost]
        public bool ChangeStatus(int id)
        {
            var result = new DonDatHangDAO().ChangeStatus(id);
            return result;
        }
    }
}