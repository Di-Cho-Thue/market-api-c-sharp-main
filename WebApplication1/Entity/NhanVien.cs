using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Entity
{
    public partial class NhanVien
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string manhanvien { get; set; }
        public string hoten_nv { get; set; }
        public string cmnd_nv { get; set; }
        public DateTime ngaysinh_nv { get; set; }
        public string gioitinh_nv { get; set; }
        public string sonha_nv { get; set; }
        public string phuongxa_nv { get; set; }
        public string quanhuyen_nv { get; set; }
        public string thanhpho_nv { get; set; }
        public string bophan { get; set; }

    }
}
