using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAPI.Entity
{
    public class KhachHang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string makhachhang { set; get; }
        public string hoten_kh { set; get; }
        public string cmnd_kh { set; get; }
        public DateTime ngaysinh_kh { set; get; }
        public string gioitinh_kh { set; get; }
        public string sonha_kh { set; get; }
        public string phuongxa_kh { set; get; }
        public string quanhuyen_kh { set; get; }
        public string thanhpho_kh { set; get; }
        public string sodienthoai_kh { set; get; }
    }
}
