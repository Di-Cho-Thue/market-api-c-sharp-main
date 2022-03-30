using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAPI.Entity
{
    public class DoanhThu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string tensanpham { set; get; }
        public decimal doanhthu { set; get; }
    }
}
