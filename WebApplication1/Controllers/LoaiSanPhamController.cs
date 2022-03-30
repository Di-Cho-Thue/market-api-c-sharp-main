using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketAPI.Entity;
using MarketAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSanPhamController : ControllerBase
    {
        private readonly ModelContext _context;
        public LoaiSanPhamController(ModelContext context)
        {
            _context = context;
        }

        //GET api/loaisanpham
        [HttpGet]
        public IEnumerable<LoaiSanPham> Get()
        {
            return _context.LoaiSanPham.ToList();
        }

        // POST api/loaisanpham
        [HttpPost]
        public void Post([FromBody] LoaiSanPham loaisanpham)
        {
            _context.LoaiSanPham.Add(loaisanpham);
            _context.SaveChanges();
        }

        // PUT api/loaisanpham/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] LoaiSanPham loaisanpham)
        {
            var tloaisanpham = _context.LoaiSanPham.FirstOrDefault(nv => nv.maloaisanpham == id);
            if (tloaisanpham != null)
            {
                _context.Entry<LoaiSanPham>(tloaisanpham).CurrentValues.SetValues(loaisanpham);
                _context.SaveChanges();
            }
        }

        // DELETE api/loaisanpham/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var loaisanpham = _context.LoaiSanPham.FirstOrDefault(nv => nv.maloaisanpham == id);
            if (loaisanpham != null)
            {
                _context.LoaiSanPham.Remove(loaisanpham);
                _context.SaveChanges();
            }
        }
    }
}