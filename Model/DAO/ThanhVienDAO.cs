using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class ThanhVienDAO
    {
        LaptopShopDbContext db = null;
        public ThanhVienDAO()
        {
            db = new LaptopShopDbContext();
        }

        public ThanhVien GetbyID(string taikhoan)
        {
            return db.ThanhViens.SingleOrDefault(x => x.TaiKhoan == taikhoan);
        }

        public int Login(string taikhoan, string matkhau)
        {
            var result = db.ThanhViens.SingleOrDefault(x => x.TaiKhoan == taikhoan );
            if (result == null)
            {
                return 0;
            }
            else if (result.MaLoaiTV == 1)
            {
                return -2;
            }
            else
            {             
                    if (result.MatKhau == matkhau)
                        return 1;
                    else
                        return -1;
                }

            }

        }
    }

