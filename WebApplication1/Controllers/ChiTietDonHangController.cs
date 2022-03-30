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
    public class ChiTietDonHangController : ControllerBase
    {
        private readonly ModelContext _context;
        public ChiTietDonHangController(ModelContext context)
        {
            _context = context;
        }
        // GET: api/chitietdonhang
        [HttpGet]
        public IEnumerable<ChiTietDonHang> Get()
        {
            return _context.ChiTietDonHang.ToList();
        }

        // GET: api/chitietdonhang
        [HttpGet("{madonhang}")]
        public Object GetDanhSachChiTietSanPham(string madonhang)
        {
            if (madonhang.Length == 0)
            {
                return null;
            }

            IEnumerable<ChiTietDonHang> chiTietDonHangs = _context.ChiTietDonHang.AsNoTracking().Where(ctdh => ctdh.madonhang == madonhang).ToList();
            List<SanPham> sanPhams = new List<SanPham>();
            foreach (ChiTietDonHang chiTietDonHang in chiTietDonHangs)
            {
                SanPham sanPham = _context.SanPham.AsNoTracking().Where(sp => sp.masanpham == chiTietDonHang.masanpham).FirstOrDefault();
                sanPham.ChiTietDonHang = chiTietDonHang;
                sanPhams.Add(sanPham);
            }
            return sanPhams;
        }
        // POST api/donhang
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public void Post([FromBody] ChiTietDonHang chitietdonhang)
        {
            _context.ChiTietDonHang.Add(chitietdonhang);
            _context.SaveChanges();
        }
    }
}