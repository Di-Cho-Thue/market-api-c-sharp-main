using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Entity
{
    public partial class LoaiSanPham
    {
        public LoaiSanPham()
        {
            sanpham = new HashSet<SanPham>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string maloaisanpham { get; set; }
        public string tenloaisanpham { get; set; }
        public string hinhanhloaisanpham { get; set; }
        public virtual ICollection<SanPham> sanpham { get; set; }
    }
}
