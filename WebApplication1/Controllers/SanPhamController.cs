using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketAPI.Entity;
using MarketAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ModelContext _context;
        public SanPhamController(ModelContext context)
        {
            _context = context;
        }

        //GET api/sanpham
        [HttpGet]
        public IEnumerable<SanPham> Get()
        {
            return _context.SanPham.ToList();
        }

        //GET api/sanpham/{id}
        [HttpGet("{id}")]
        public SanPham GetSanPham(string id)
        {
            return _context.SanPham.FirstOrDefault(sp => sp.masanpham == id);
        }

        //GET api/sanpham/gianhangsp/{id}
        [HttpGet("gianhangsp/{id}")]
        public IEnumerable<SanPham> GetSanPhamTheoGianHang(string id)
        {
            return _context.SanPham.Where(sp => sp.gianhang == id && sp.tinhtrangsanpham != "Đã xóa");
        }

        //GET api/sanpham/loaisanpham/{id}
        [HttpGet("loaisanpham/{id}")]
        public IEnumerable<SanPham> GetSanPhamByLoaiSanPham(string id)
        {
            return _context.SanPham.Where(sp => sp.loaisanpham == id);
        }

        //Pagination
        [HttpGet("loaisanpham/{id}/{page}/{limit}")]
        public IEnumerable<SanPham> GetSanPhamPaginaition(string id, int page, int limit)
        {
            if(page == null && limit == null)
            {
                page = 0;
                limit = 12;
            }
            return _context.SanPham.Where(sp => sp.loaisanpham == id).Skip(page * limit).Take(limit).ToList();
        }

        [HttpGet("{thongtin}/{page}/{limit}")]
        public IEnumerable<SanPham> SearchSanPhamPaginaition(string thongtin, int page, int limit)
        {
            if (page == null && limit == null)
            {
                page = 0;
                limit = 12;
            }

            return _context.SanPham.Where(sp => sp.tensanpham.Contains(thongtin)).Skip(page * limit).Take(limit).ToList();
        }

        // POST api/sanpham
        [HttpPost]
        public void Post([FromBody] SanPham sanpham)
        {
            _context.SanPham.Add(sanpham);
            _context.SaveChanges();
        }

        // PUT api/sanpham/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] SanPham sanpham)
        {
            var tsanpham = _context.SanPham.FirstOrDefault(nv => nv.masanpham == id);
            if (tsanpham != null)
            {
                tsanpham.tensanpham = sanpham.tensanpham;
                tsanpham.giasanpham = sanpham.giasanpham;
                tsanpham.motasanpham = sanpham.motasanpham;
                tsanpham.soluongton = sanpham.soluongton;
                tsanpham.hinhanh = sanpham.hinhanh;
                _context.SaveChanges();
            }
        }

        // PUT api/sanpham/updatefile
        [HttpPut("updatefile")]
        public void UpdateProductUsingFile([FromBody] IEnumerable<SanPham> sanpham)
        {
            foreach (var item in sanpham)
            {
                var tsanpham = _context.SanPham.FirstOrDefault(nv => nv.masanpham == item.masanpham);
                tsanpham.tensanpham = item.tensanpham;
                tsanpham.giasanpham = item.giasanpham;
                tsanpham.motasanpham = item.motasanpham;
                tsanpham.soluongton = item.soluongton;
                tsanpham.loaisanpham = item.loaisanpham;
                tsanpham.hinhanh = item.hinhanh;
                _context.SaveChanges();
            }
        }

        // PUT api/sanpham/removeproduct
        [HttpPut("removeproduct/{id}")]
        public void DeleteProduct(string id)
        {
            var tsanpham = _context.SanPham.FirstOrDefault(nv => nv.masanpham == id);
            if (tsanpham != null)
            {
                tsanpham.tinhtrangsanpham = "Đã xóa";
                _context.SaveChanges();
            }
        }
    }
}