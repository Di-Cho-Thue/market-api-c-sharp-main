using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAPI.Entity
{
    public class DonHang
    {


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string madonhang { set; get; }
        public string hinhthucthanhtoan { set; get; }
        public DateTime ngaylapdon { set; get; }
        public string tinhtrangdon { set; get; }
        public decimal tongtien { set; get; }
        public string khuyenmai { set; get; }
        public string makhachhang { set; get; }
        public string manguoigiaohang { set; get; }
        public string gianhang { set; get; }


    }
}
