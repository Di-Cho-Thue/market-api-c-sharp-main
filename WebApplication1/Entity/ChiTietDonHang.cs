using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarketAPI.Entity
{
    public class ChiTietDonHang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string madonhang { set; get; }
        public string masanpham { set; get; }
        public decimal dongia { set; get; }
        public int soluong { set; get; }
    }
}
