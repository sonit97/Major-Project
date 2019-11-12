namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonDatHang")]
    public partial class DonDatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonDatHang()
        {
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
        }

        [Key]
        public int MaDDH { get; set; }

        public DateTime? NgayDat { get; set; }

        public int TinhTrang { get; set; }

       // public DateTime? NgayGiao { get; set; }

     

        public int MaKH { get; set; }

        public int? UuDai { get; set; }
        [StringLength(50)]
        public string NVGiaoHang { get; set; }

        public int? TinhTrangGH { get; set; }

        public decimal? TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
