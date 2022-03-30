using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Entity
{
    public partial class SanPham
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string masanpham { get; set; }
        public string tensanpham { get; set; }
        public decimal giasanpham { get; set; }
        public double danhgiasanpham { get; set; }
        public string motasanpham { get; set; }
        public int soluongton { get; set; }
        public string tinhtrangduyet { get; set; }
        public string tinhtrangsanpham { get; set; }
        public string manhanvienduyet { get; set; }
        public string loaisanpham { get; set; }
        public string gianhang { get; set; }
        public string hinhanh { get; set; }

        [Column("LoaiSanPham")]
        [Display(Name = "MaLoaiSanPham:")]
        public string maloaisanpham { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }

        public virtual ChiTietDonHang ChiTietDonHang { get; set; }

        [Column("GianHang")]
        [Display(Name = "MaGianHang:")]
        public string magianhang { get; set; }
        public virtual GianHang GianHang { get; set; }
    }
}
