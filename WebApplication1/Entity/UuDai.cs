using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAPI.Entity
{
    public class UuDai
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string mauudai { set; get; }
        public string dieukienapdung { set; get; }
        public int phantramkm { set; get; }
        public decimal toidakm { set; get; }
    }
}
