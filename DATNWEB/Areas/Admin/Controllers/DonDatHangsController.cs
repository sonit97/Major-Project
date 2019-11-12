using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATNWEB.Areas.Admin.Controllers
{
    public class DonDatHangsController : BaseController
    {
        LaptopShopDbContext db = new LaptopShopDbContext();
        // GET: Admin/DonDatHangs
        public ActionResult Index()
        {
            //tat ca don hang
            var listddh = db.DonDatHangs;

            return View(listddh);
        }
        [HttpGet]
        public ActionResult Chitiet(int MaDDH)
        {
            var dh = db.ChiTietDonDatHangs.Where(x=>x.MaDDH==MaDDH);
            return View(dh);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            db.DonDatHangs.Remove(donDatHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DuyetDonHang(int ma)
        {
           // ViewBag.MaLoaiTV = new SelectList(db.LoaiThanhViens.Where(x => x.MaLoaiTV != 1), "MaLoaiTV", "TenLoai");
           // ViewBag.NVGH = db.ThanhViens.Where(x => x.MaLoaiTV == 3);
            DonDatHangDAO ddh = null;
            if (ma != 0)
            {
                var dh = db.DonDatHangs.Where(x => x.TinhTrang == 0);
                // ddh = new DonDatHangDAO();
                ChangeStatus(ma);
                ViewBag.MaThanhVien = new SelectList(db.ThanhViens.Where(x => x.MaLoaiTV == 3), "MaThanhVien", "Hoten");
                //  ViewBag.NVGH = new SelectList(db.ThanhViens.Where(x => x.MaLoaiTV == 3), "Hoten", "NVGiaoHang");
                // List<DonDatHangDAO> list = ddh.getlist(mathanhvien);
                return View(dh);
            }
            else
            {
                var dh = db.DonDatHangs.Where(x => x.TinhTrang == 0);
                //ddh = new DonDatHangDAO();
                //ChangeStatus(36);
                ViewBag.MaThanhVien = new SelectList(db.ThanhViens.Where(x => x.MaLoaiTV == 3), "MaThanhVien", "Hoten");
                // List<DonDatHangDAO> list = ddh.getlist(mathanhvien);
                return View(dh);
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
        //duyet don hang
        //[HttpPost]
        public bool ChangeStatus(int id)
        {
            var result = new DonDatHangDAO().ChangeStatus1(id);
            return result;
        }
        [HttpGet]
        public ActionResult DonHangGiao()
        {
            var dh = db.DonDatHangs.Where(x => x.TinhTrang == 1);
            return View(dh);

        }

        public ActionResult DonHangDaDuyet()
        {
          //  var dh = db.DonDatHangs.Where(x => x.TinhTrang == 1);
            var dhhh = db.ChiTietDonDatHangs.Where(a => a.DonDatHang.TinhTrang == 1);

          
            return View(dhhh);

        }

    }
}
