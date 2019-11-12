using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DATNWEB.Common
{
    [Serializable]
    public class UserLogin
    {
      
        public int UsetID { set; get; }
        public string TenTaiKhoan { set; get; }
        public string HoTen { set; get; }
        public int? MaLoaiTV { set; get; }
    }
}