using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Entity
{
    public partial class GianHang
    {
        public GianHang()
        {
            sanpham = new HashSet<SanPham>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string magianhang { get; set; }
        public string tengianhang { get; set; }
        public string msdn_nguoiban { get; set; }
        public string sonha_gh { get; set; }
        public string phuongxa_gh { get; set; }
        public string quanhuyen_gh { get; set; }
        public string thanhpho_gh { get; set; }
        public string motagianhang { get; set; }

        public string tinhtranggianhang { get; set; }

        public double danhgiagianhang { get; set; }
        public int luottheodoi_gh { get; set; }
        public string loaigianhang { get; set; }

        public string matkhau { get; set; }
        public string email_gh { get; set; }
        public string sdt_gh { get; set; }
        public string giaytocovid { get; set; }
        public string giaytosanpham { get; set; }


        [Column("LoaiGianHang")]
        [Display(Name = "MaLoaiGianHang:")]
        public string maloaigianhang { get; set; }
        public virtual LoaiGianHang LoaiGianHang { get; set; }
        public virtual ICollection<SanPham> sanpham { get; set; }
    }
}
