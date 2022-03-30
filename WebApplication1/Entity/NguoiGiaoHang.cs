using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Entity
{
    public partial class NguoiGiaoHang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string manguoigiaohang { get; set; }
        public string hoten_ngh { get; set; }
        public string cmnd_ngh { get; set; }
        public DateTime ngaysinh_ngh { get; set; }
        public string gioitinh_ngh { get; set; }
        public string sonha_ngh { get; set; }
        public string phuongxa_ngh { get; set; }
        public string quanhuyen_ngh { get; set; }
        public string thanhpho_ngh { get; set; }
        public string sodienthoai_ngh { get; set; }
        public double danhgia_ngh { get; set; }
        public string giaypheplaixe { get; set; }
        public string giayxacnhanamtinh { get; set; }
        public string tinhtrangduyet { get; set; }
        public string tinhtranghoatdong { get; set; }
        public string tendangnhap { get; set; }
        public string matkhau { get; set; }
    }
}
