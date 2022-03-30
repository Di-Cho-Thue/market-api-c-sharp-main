using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketAPI.Entity;
using MarketAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Cors;

namespace MarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]

    public class DonHangController : ControllerBase
    {
        private readonly ModelContext _context;
        public DonHangController(ModelContext context)
        {
            _context = context;
        }
        // GET: api/<DonHangController>
        // if has shipper id then return pending state order nearby
        [HttpGet]
        public IEnumerable<DonHang> Get([FromQuery(Name = "shipper")] string shipper)
        {
            if (shipper != null)
            {
                NguoiGiaoHang nguoiGiaoHang = _context.NguoiGiaoHang.Where(n => n.manguoigiaohang == shipper).FirstOrDefault();
                string phuongxa = nguoiGiaoHang.phuongxa_ngh;
                string quanhuyen = nguoiGiaoHang.quanhuyen_ngh;
                string thanhpho = nguoiGiaoHang.thanhpho_ngh;
                List<KhachHang> khachHangs = _context.KhachHang.Where(kh => kh.phuongxa_kh == phuongxa && kh.quanhuyen_kh == quanhuyen && kh.thanhpho_kh == thanhpho).ToList();
                List<DonHang> donHangs = new List<DonHang>();
                foreach (KhachHang khachHang in khachHangs)
                {
                    List<DonHang> donHang = _context.DonHang.Where(dh => dh.makhachhang == khachHang.makhachhang && dh.tinhtrangdon == "Đang lấy hàng" && dh.manguoigiaohang == null).ToList();
                    donHangs.AddRange(donHang);
                }
                List<DonHang> donHangs1 = _context.DonHang.Where(dh => dh.manguoigiaohang == shipper && dh.tinhtrangdon != "Đang lấy hàng" && dh.tinhtrangdon != "Chờ xác nhận").ToList();
                donHangs.AddRange(donHangs1);
                return donHangs;
            }
            return _context.DonHang.ToList();
        }

        // GET api/DonHang/magianhang/tinhtrangdon/time
        [HttpGet("{magianhang}/{tinhtrangdon}/{thoigian}")]
        public ActionResult GetDonHangByMaGianHang(string magianhang, string tinhtrangdon, string thoigian)
        {

            string t = "select * from donhang where gianhang='";
            t = t + magianhang + "'";
            if (tinhtrangdon != "all")
            {
                t = t + " and tinhtrangdon=N'" + tinhtrangdon + "'";
            }
            if (thoigian != "all")
            {
                if (thoigian == "trong hôm nay")
                {
                    t = t + " and CONVERT(date,ngaylapdon)=CONVERT(date,GETDATE())";
                }
                if (thoigian == "từ hôm qua")
                {
                    t = t + " and CONVERT(date,ngaylapdon)<=CONVERT(date,GETDATE()) and CONVERT(date,ngaylapdon)>=DATEADD(day, -1,CONVERT(date,GETDATE())) ";
                }
                if (thoigian == "từ hôm kia")
                {
                    t = t + " and CONVERT(date,ngaylapdon)<=CONVERT(date,GETDATE()) and CONVERT(date,ngaylapdon)>=DATEADD(day, -2,CONVERT(date,GETDATE())) ";
                }
                if (thoigian == "trong tháng")
                {
                    t = t + " and month(ngaylapdon)=month(GETDATE()) ";
                }
                if (thoigian == "trong tuần")
                {
                    t = t + " and week(ngaylapdon)=week(GETDATE()) ";
                }


            }


            var test = from dh in _context.DonHang.FromSql(t)
                       join ctdh in _context.ChiTietDonHang on dh.madonhang equals ctdh.madonhang
                       join sp in _context.SanPham on ctdh.masanpham equals sp.masanpham
                       select new
                       {
                           MaDonHang = dh.madonhang,
                           ThanhToan = dh.hinhthucthanhtoan,
                           NgayLap = dh.ngaylapdon,
                           TinhTrang = dh.tinhtrangdon,
                           TongTien = dh.tongtien,
                           KhachHang = dh.makhachhang,
                           NguoiGiao = dh.manguoigiaohang,
                           TenSanPham = sp.tensanpham,
                           GiaSanPham = sp.giasanpham,
                           SoLuong = ctdh.soluong
                       };
            return Ok(test);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET api/DonHang/5
        [HttpGet("{magianhang}")]
        public List<DonHang> GetDonHangByMaGianHang(string magianhang)
        {
            return _context.DonHang.Where(dh => dh.gianhang == magianhang).ToList();
        }

        [HttpGet("detail/{madonhang}")]
        public DonHang GetDonhangByMaDonHang(string madonhang)
        {
            DonHang donHang = _context.DonHang.Where(dh => dh.madonhang == madonhang).FirstOrDefault();
            return donHang;
        }

        [HttpPost("accept/{madonhang}")]
        public bool ChapNhanGiaoHang(string madonhang, [FromBody] DonHang data)
        {
            DonHang donHang = _context.DonHang.Where(dh => dh.madonhang == madonhang).FirstOrDefault();
            if (donHang.tinhtrangdon == "Đang lấy hàng" && donHang.manguoigiaohang == null)
            {
                donHang.manguoigiaohang = data.manguoigiaohang;
                _context.DonHang.Update(donHang);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        // POST api/donhang
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public void Post([FromBody] DonHang donhang)
        {
            _context.DonHang.Add(donhang);
            _context.SaveChanges();
        }

        [HttpPost("update/{madonhang}")]
        public ActionResult PostUpdate(string madonhang, [FromBody] DonHang donHang)
        {
            var tdonhang = _context.DonHang.FirstOrDefault(nv => nv.madonhang == madonhang);
            if (tdonhang != null)
            {
                if (tdonhang.manguoigiaohang != null)
                {
                    return Forbid();
                }
                _context.Entry<DonHang>(tdonhang).CurrentValues.SetValues(donHang);
                _context.SaveChanges();
                return Ok(tdonhang);
            }
            return NotFound();
        }


        // PUT api/<DonHangController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] DonHang donHang)
        {
            var tdonhang = _context.DonHang.FirstOrDefault(nv => nv.madonhang == id);
            if (tdonhang != null)
            {
                if (tdonhang.manguoigiaohang != donHang.manguoigiaohang)
                {
                    return Forbid();
                }
                _context.Entry<DonHang>(tdonhang).CurrentValues.SetValues(donHang);
                _context.SaveChanges();
                return Ok(tdonhang);
            }
            return NotFound();
        }

        // PUT api/donhang/xacnhan
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost("xacnhan/{id}")]
        public void XacNhanDonHang(string id)
        {
            var tdonhang = _context.DonHang.FirstOrDefault(nv => nv.madonhang == id);
            if (tdonhang != null)
            {
                tdonhang.tinhtrangdon = "Đang lấy hàng";
                _context.SaveChanges();
            }
        }
    }
}
