using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Entity
{
    public partial class LoaiGianHang
    {
        public LoaiGianHang()
        {
            gianhang = new HashSet<GianHang>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string maloaigianhang { get; set; }
        public string tenloaigianhang { get; set; }

        public virtual ICollection<GianHang> gianhang { get; set; }
    }
}
