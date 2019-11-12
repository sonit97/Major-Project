using Model.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Model.DAO
{
    public class DonDatHangDAO
    {
        LaptopShopDbContext db = null;

        public int MaDDH { get; set; }

        public DateTime? NgayDat { get; set; }
        public int MaTV { get; set; }
        public string Description { get; set; }
        public string TenKhachHang{ get; set; }
        public string DiaChi { get; set; }
        public string ThongTin { get; set; }
        public string SDT { get; set; }
        public decimal? TongTien { get; set; }
        public int TinhTrang { get; set; }
        public DonDatHangDAO()
        {
            db = new LaptopShopDbContext();
        }
        public List<DonDatHang> Listallpaging(int id)
        {
            return db.DonDatHangs.Where(x => x.MaKH == id).ToList();

        }
        public List<DonDatHangDAO> getlist( int mtv)
        {
            List<DonDatHangDAO> list = (from a in db.ThanhViens
                                        join b in db.KhachHangs
                                        on a.MaThanhVien equals b.MaThanhVien
                                        join c in db.DonDatHangs
                                        on b.MaKH equals c.MaKH
                                        where a.MaThanhVien==mtv && a.MaThanhVien==b.MaThanhVien && b.MaKH==c.MaKH
                                        select new DonDatHangDAO
                                        {
                                            MaDDH = c.MaDDH,
                                            NgayDat = c.NgayDat,
                                            TenKhachHang=b.TenKH,
                                            DiaChi=b.DiaChi,                                     
                                            SDT=b.SoDienThoai,
                                            MaTV=a.MaThanhVien,
                                            TinhTrang = c.TinhTrang,
                                            TongTien=c.TongTien

                                        }).ToList();
            return list;
        }
        //huy don hang
        public bool ChangeStatus(int id)
        {
            var user = db.DonDatHangs.Find(id);
            if (user.TinhTrang == 0)
            {
                user.TinhTrang = 2;
                db.SaveChanges();
            }
            //else
            //{
            //    user.TinhTrang = !user.TinhTrang;
            //    db.SaveChanges();
            //}
            
            return true;
        }
        //duyet do hang
        public bool ChangeStatus1(int id)
        {
            var user = db.DonDatHangs.Find(id);
            if (user.TinhTrang == 0)
            {
              
                user.TinhTrang = 1;
                user.TinhTrangGH = 0;
                db.SaveChanges();
            }
            //else
            //{
            //    user.TinhTrang = !user.TinhTrang;
            //    db.SaveChanges();
            //}

            return true;
        }
    }
}
