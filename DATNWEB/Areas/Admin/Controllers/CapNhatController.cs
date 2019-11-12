using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace DATNWEB.Areas.Admin.Controllers
{
    public class CapNhatController : BaseController
    {
        private LaptopShopDbContext db = new LaptopShopDbContext();

        // GET: Admin/CapNhat
        public ActionResult Index()
        {
            var donDatHangs = db.DonDatHangs.Include(d => d.KhachHang);
            return View(donDatHangs.ToList());
        }

        // GET: Admin/CapNhat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            return View(donDatHang);
        }

        // GET: Admin/CapNhat/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            return View();
        }

        // POST: Admin/CapNhat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDDH,NgayDat,TinhTrang,MaKH,UuDai,NVGiaoHang,TinhTrangGH,TongTien")] DonDatHang donDatHang)
        {
            if (ModelState.IsValid)
            {
                db.DonDatHangs.Add(donDatHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", donDatHang.MaKH);
            return View(donDatHang);
        }

        // GET: Admin/CapNhat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }

            set();
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", donDatHang.MaKH);
            return View(donDatHang);
        }
        public void set(int? selectedID = null)
        {


            ViewBag.NVGiaoHang = new SelectList(db.ThanhViens.Where(x => x.MaLoaiTV == 3), "MaThanhVien", "Hoten", selectedID);
        }

        // POST: Admin/CapNhat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDDH,NgayDat,TinhTrang,MaKH,UuDai,NVGiaoHang,TinhTrangGH,TongTien")] DonDatHang donDatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donDatHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DonHangDaDuyet", "DonDatHangs");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", donDatHang.MaKH);
            return RedirectToAction("DonHangDaDuyet", "DonDatHangs");
        }

        // GET: Admin/CapNhat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("DonHangDaDuyet","DonDatHangs");
        }

        // POST: Admin/CapNhat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            db.DonDatHangs.Remove(donDatHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
