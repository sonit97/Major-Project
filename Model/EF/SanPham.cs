namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            BinhLuans = new HashSet<BinhLuan>();
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
            ChiTietPhieuNhapps = new HashSet<ChiTietPhieuNhapp>();
        }

        [Key]
        [Display(Name = "Mã Sản Phẩm")]
        public int MaSP { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên Sản Phẩm")]
        public string TenSP { get; set; }

        [Display(Name = "Đơn Giá")]
        public decimal? DonGia { get; set; }
        [Display(Name = "Ngày Cập Nhật")]
        public DateTime? NgayCapNhat { get; set; }
        [Display(Name = "Cấu Hình")]
        public string CauHinh { get; set; }
        [Display(Name = "Mô Tả")]
        public string MoTa { get; set; }
        [Display(Name = "Hình Ảnh")]
        public string HinhAnh { get; set; }
        [Display(Name = "Số Lượng Tồn")]
        [Range(typeof(int),"1","1000",ErrorMessage ="Số lượng không được nhỏ hơn 0!")]
        public int? SoLuongTon { get; set; }

        // public int? LuotXem { get; set; }

        // public int? LuotBinhChon { get; set; }

        // public int? LuotBinhLuan { get; set; }

        // public int? SoLanMua { get; set; }
        [Display(Name = "Tình Trạng")]
        public string TinhTrang { get; set; }

        [Display(Name = "Nhà Cung Cấp")]
        public int? MaNCC { get; set; }

        [Display(Name = "Nhà Sản Xuất")]
        public int? MaNSX { get; set; }

        [Display(Name = "Loại Sản Phẩm")]
        public int? MaLoaiSP { get; set; }

        // public bool? DaXoa { get; set; }
        [Display(Name = "Hình Ảnh 1")]
        public string HinhAnh1 { get; set; }
        [Display(Name = "Hình Ảnh 2")]
        public string HinhAnh2 { get; set; }
        [Display(Name = "Hình Ảnh 3")]
        public string HinhAnh3 { get; set; }

       
       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhapp> ChiTietPhieuNhapps { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual NhaSanXuat NhaSanXuat { get; set; }
    }
}
