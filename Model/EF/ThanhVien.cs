namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhVien")]
    public partial class ThanhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThanhVien()
        {
            BinhLuans = new HashSet<BinhLuan>();
            KhachHangs = new HashSet<KhachHang>();
        }

        [Key]
    
        public int MaThanhVien { get; set; }

        [StringLength(50)]   
        [Required(ErrorMessage ="Mời nhập tài khoản!")]
        public string TaiKhoan { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Mời nhập mật khẩu!")]
        public string MatKhau { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Mời nhập họ tên!")]
        public string Hoten { get; set; }

        [StringLength(5)]
        [Required(ErrorMessage = "Mời chọn giới tính!")]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Mời nhập địa chỉ!")]
        public string DiaChi { get; set; }

        [StringLength(12)]
        [Required(ErrorMessage = "Mời nhập Sđt!")]
        [RegularExpression(@"^\d{9,11}$", ErrorMessage = "Sai định dạng sđt!")]
        public string SoDienThoai { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mời nhập email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail sai định dạng!")]
        public string Email { get; set; }

        public int? MaLoaiTV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }

        public virtual LoaiThanhVien LoaiThanhVien { get; set; }
    }
}
