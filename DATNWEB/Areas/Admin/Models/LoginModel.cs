using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DATNWEB.Areas.Admin.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Mời nhập tài khoản")]
        public string TaiKhoan { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string MatKhau { get; set; }
        public int MaLoaiTV { get; set; }

    }
}