using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAPI.Entity
{
    public class GiayTo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string magiayto { set; get; }
        public string gianhang { set; get; }
        public string loaigiayto { set; get; }
        public string hinhanh { set; get; }
    }
}
