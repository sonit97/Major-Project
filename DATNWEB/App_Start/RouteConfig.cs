using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DATNWEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //-------------Đường dẫn tới sản phẩm.
            routes.MapRoute(
            name: "SanPham",
            url: "SanPham/MaLoaiSP={MaLoaiSP}-MaNSX={MaNSX}",          
            defaults: new { controller = "SanPham", action = "SanPham", id = UrlParameter.Optional }
        );

            //--------------Đường dẫn chi tiet san pham
            routes.MapRoute(
              name: "XemChiTiet",
              url: "{tensp}-{id}",
              defaults: new { controller = "SanPham", action = "XemChiTiet", id = UrlParameter.Optional }
          );
            //-------------Tìm kiếm
            routes.MapRoute(
               name: "Search",
               url: "tim-kiem",
               defaults: new { controller = "SanPham", action = "Search", id = UrlParameter.Optional }
     );

            //---------------
            //-------------trang ca nhan
            routes.MapRoute(
               name: "CaNhan",
               url: "{controller}/ca-nhan",
               defaults: new { controller = "KhachHang", action = "Index", id = UrlParameter.Optional }
     );
            //--------------Đường dẫn xem đơn hàng
            routes.MapRoute(
              name: "XemDonHang",
               url: "don-hang/{mathanhvien}-{ma}",
              defaults: new { controller = "KhachHang", action = "XemDonHang", id = UrlParameter.Optional }
          );
            //----duyet don hang
            routes.MapRoute(
           name: "DuyetDonHang",
            url: "Duyet-Don-Hangs/-{ma}",
           defaults: new { controller = "DonDatHangs", action = "DuyetDonHang", id = UrlParameter.Optional }
       );
            //     //--------------
            routes.MapRoute(
         name: "ChiTietDonDatHang",
          url: "{ma}",
         defaults: new { controller = "DonDatHangs", action = "Chitiet", id = UrlParameter.Optional }
     );


            //------
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
