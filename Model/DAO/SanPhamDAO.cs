using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.DAO
{
   public class SanPhamDAO
    {
        LaptopShopDbContext db = null;
        public SanPhamDAO()
        {
            db = new LaptopShopDbContext();
        }
        public List<string> ListName(string keyword)
        {
            return db.SanPhams.Where(x => x.TenSP.Contains(keyword)).Select(x => x.TenSP).ToList();
        }

        public List<SanPhamViewModel> Search(string keyword, ref int totalRecord)
        {
            totalRecord = db.SanPhams.Where(x => x.TenSP == keyword).Count();
            var model = (from a in db.SanPhams
                             //join b in db.ProductCategories
                             //on a.CategoryID equals b.ID
                         where a.TenSP.Contains(keyword)
                         select new
                         {
                             MaSP = a.MaSP,
                             HinhAnh = a.HinhAnh,
                             TenSP = a.TenSP,                           
                             DonGia = a.DonGia
                         }).AsEnumerable().Select(x => new SanPhamViewModel()
                         {
                             MaSP =x.MaSP,
                             HinhAnh = x.HinhAnh,
                             TenSP = x.TenSP,
                             DonGia = x.DonGia
                         });
            //model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

    }
}
