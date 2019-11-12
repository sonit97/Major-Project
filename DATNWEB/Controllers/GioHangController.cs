using DATNWEB.Models;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATNWEB.Controllers
{
    public class GioHangController : Controller
    {
        LaptopShopDbContext db = new LaptopShopDbContext();
        //Lấy giỏ hàng
        public List<ItemGioHang> LayGioHang()
        {
          
            List<ItemGioHang> listGioHang = Session["Giohang"] as List<ItemGioHang>;
            if (listGioHang == null)
            {
                
                listGioHang = new List<ItemGioHang>();
                Session["GioHang"] = listGioHang;
             
            }
            return listGioHang;

        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int MaSP,string strURL)
        {
           
            SanPham sp= db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng
            List<ItemGioHang> listGioHang = LayGioHang();
        
            ItemGioHang spCheck = listGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if(spCheck != null)
            {
               
                if(sp.SoLuongTon<spCheck.SoLuong)
                {
                    return View("ThongBao");
                }
                spCheck.SoLuong++;
                spCheck.ThanhTien = spCheck.SoLuong * spCheck.DonGia;
                return Redirect(strURL);

            }
           
            ItemGioHang itemGH = new ItemGioHang(MaSP);
            if (sp.SoLuongTon < itemGH.SoLuong)
            {
                return View("ThongBao");
            }
            listGioHang.Add(itemGH);
            return Redirect(strURL); 
        }


    
       
        public double TinhTongSoLuong()
        {
           
            List<ItemGioHang> listGioHang = Session["GioHang"] as List<ItemGioHang>;
            if(listGioHang == null)
            {
                return 0;
            }
            return listGioHang.Sum(n => n.SoLuong);
        }
        
        public decimal TinhTongTien()
        {

           
            List<ItemGioHang> listGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (listGioHang == null)
            {
                return 0;
            }
            return listGioHang.Sum(n => n.ThanhTien);
        }
        // GET: GioHang
        public ActionResult XemGioHang()
        {
           
            List<ItemGioHang> listGioHang = LayGioHang();
            ViewBag.TongTien = TinhTongTien();
            return View(listGioHang);
        }

        
        [HttpGet]
        public ActionResult SuaGioHang(int MaSP)
        {
           
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index","Home");
            }
            
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            
            List<ItemGioHang> listGioHang = LayGioHang();
         
            ItemGioHang spCheck = listGioHang.SingleOrDefault(n=>n.MaSP==MaSP);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
           
            ViewBag.GioHang = listGioHang;
            
            return View(spCheck);
        }
        
        public ActionResult GioHangPartial()
        {
            if (TinhTongSoLuong() == 0)
            {
                ViewBag.TongSoLuong = 0;
                ViewBag.TongTien = 0;
                return PartialView();
            }
            ViewBag.TongSoLuong = TinhTongSoLuong();
            ViewBag.TongTien = TinhTongTien();
            return PartialView();
        }
        //Xử lý cập nhật giỏ hàng
        [HttpPost]
        public ActionResult CapNhatGioHang(ItemGioHang itemGH)
        {
            //Kiểm tra só lượng tồn
            SanPham spCheck = db.SanPhams.SingleOrDefault(n => n.MaSP == itemGH.MaSP);
            if (spCheck.SoLuongTon < itemGH.SoLuong)
            {
                return View("ThongBao");
            }
            //Cập nhật số lượng trong session giỏ hàng
            //b1 :lấy list<GioHang> từ session từ session["GioHang"]
            List<ItemGioHang> listGH = LayGioHang();
            //b2:Láy sản phẩm cần nhật từ trong list<GioHang> ra
            ItemGioHang itemGHUpdate = listGH.Find(n=>n.MaSP==itemGH.MaSP);
            //b3: Tiến hành cập nhật lại số lượng cững như thành tiền
            itemGHUpdate.SoLuong = itemGH.SoLuong;
            itemGHUpdate.ThanhTien = itemGHUpdate.SoLuong * itemGHUpdate.DonGia;
            return RedirectToAction("XemGioHang");
        }
        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int MaSP)
        {
           
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
          
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            
            List<ItemGioHang> listGioHang = LayGioHang();
            
            ItemGioHang spCheck = listGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
            
            listGioHang.Remove(spCheck);
            return RedirectToAction("XemGioHang");
        }
        //Xây dựng chức năng đặt hàng
        public ActionResult DatHang(KhachHang kh)
        {
           
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            KhachHang khang = new KhachHang();
            if (Session["TaiKhoan"] == null)
            {
           
               
                khang = kh;
                db.KhachHangs.Add(khang);
                db.SaveChanges();

            }
            else
            {
                ThanhVien tv = Session["TaiKhoan"] as ThanhVien;
                khang = kh;
                db.KhachHangs.Add(khang);
                db.SaveChanges();
            }
          
            DonDatHang ddh = new DonDatHang();
            ddh.MaKH =int.Parse(khang.MaKH.ToString());
            ddh.NgayDat = DateTime.Now;
            ddh.TinhTrang = 0;
             ddh.TinhTrangGH = null;
            ddh.NVGiaoHang = null;
            ddh.UuDai = 0;
            db.DonDatHangs.Add(ddh);
            db.SaveChanges();
           
            List<ItemGioHang> lstGH = LayGioHang();
            foreach(var item in lstGH)
            {
                SanPham sp = new SanPham();
                ChiTietDonDatHang ctdh = new ChiTietDonDatHang();
                ctdh.MaDDH = ddh.MaDDH;
                ctdh.MaSP = item.MaSP;
                ctdh.TenSP = item.TenSP;
                ctdh.SoLuong = item.SoLuong;
                ctdh.DonGia = item.DonGia;
                db.ChiTietDonDatHangs.Add(ctdh);
                // Trừ số lượng
                //SanPham spCheck = db.SanPhams.SingleOrDefault(n => n.MaSP == item.MaSP);
                //if (spCheck.SoLuongTon > item.SoLuong)
                //{
                //    spCheck.SoLuongTon = spCheck.SoLuongTon - item.SoLuong;
                //}
            }
           

            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("XemGioHang");
        }
       

    }
}