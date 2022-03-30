using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MarketAPI.Entity
{
    public class TinhTrangVanDon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string madonhang { set; get; }
        public DateTime thoigiancapnhat { set; get; }
        public string trangthai { set; get; }

    }
}
