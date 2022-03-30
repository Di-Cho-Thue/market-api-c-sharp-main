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
    public class LoaiGianHangController : ControllerBase
    {
        private readonly ModelContext _context;
        public LoaiGianHangController(ModelContext context)
        {
            _context = context;
        }

        //GET api/loaigianhang
        [HttpGet]
        public IEnumerable<LoaiGianHang> Get()
        {
            return _context.LoaiGianHang.ToList();
        }

        // POST api/loaigianhang
        [HttpPost]
        public void Post([FromBody] LoaiGianHang loaigianhang)
        {
            _context.LoaiGianHang.Add(loaigianhang);
            _context.SaveChanges();
        }

        // PUT api/loaigianhang/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] LoaiGianHang loaigianhang)
        {
            var tloaigianhang = _context.LoaiGianHang.FirstOrDefault(nv => nv.maloaigianhang == id);
            if (tloaigianhang != null)
            {
                _context.Entry<LoaiGianHang>(tloaigianhang).CurrentValues.SetValues(loaigianhang);
                _context.SaveChanges();
            }
        }

        // DELETE api/gianhang/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var loaigianhang = _context.LoaiGianHang.FirstOrDefault(nv => nv.maloaigianhang == id);
            if (loaigianhang != null)
            {
                _context.LoaiGianHang.Remove(loaigianhang);
                _context.SaveChanges();
            }
        }
    }
}