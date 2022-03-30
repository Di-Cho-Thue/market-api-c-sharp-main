using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketAPI.Entity;
using MarketAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly ModelContext _context;
        public KhachHangController(ModelContext context)
        {
            _context = context;
        }

        //GET api/khachhang
        [HttpGet]
        public IEnumerable<KhachHang> Get()
        {
            return _context.KhachHang.ToList();
        }

        //GET api/khachhang/KH000001
        [HttpGet("{id}")]
        public KhachHang GetKhachHangById(string id)
        {
            return _context.KhachHang.FirstOrDefault(kh => kh.makhachhang == id);
        }

        //GET api/khachhang/vungdo
        [HttpGet("vungdo")]
        public List<KhachHang> KhachHangVungDo()
        {
            string query = "select * from KHACHHANG kh where exists(select * from VUNG where kh.PhuongXa_KH = VUNG.PhuongXa and kh.QuanHuyen_KH = VUNG.QuanHuyen and vung.LoaiVung = N'Vùng đỏ')";
            return _context.KhachHang.FromSql(query).ToList();
        }

        //GET api/khachhang/vungvang
        [HttpGet("vungvang")]
        public List<KhachHang> KhachHangVungVang()
        {
            string query = "select * from KHACHHANG kh where exists(select * from VUNG where kh.PhuongXa_KH = VUNG.PhuongXa and kh.QuanHuyen_KH = VUNG.QuanHuyen and vung.LoaiVung = N'Vùng vàng')";
            return _context.KhachHang.FromSql(query).ToList();
        }

        //GET api/khachhang/vungxanh
        [HttpGet("vungxanh")]
        public List<KhachHang> KhachHangVungXanh()
        {
            string query = "select * from KHACHHANG kh where exists(select * from VUNG where kh.PhuongXa_KH = VUNG.PhuongXa and kh.QuanHuyen_KH = VUNG.QuanHuyen and vung.LoaiVung = N'Vùng xanh')";
            return _context.KhachHang.FromSql(query).ToList();
        }
    }
}