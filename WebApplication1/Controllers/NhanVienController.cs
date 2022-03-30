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
    public class NhanVienController : ControllerBase
    {
        private readonly ModelContext _context;
        public NhanVienController(ModelContext context)
        {
            _context = context;
        }

        //GET api/nhanvien
        [HttpGet]
        public IEnumerable<NhanVien> Get()
        {
            return _context.NhanVien.ToList();
        }

        // POST api/nhanvien
        [HttpPost]
        public void Post([FromBody] NhanVien nhanvien)
        {
            _context.NhanVien.Add(nhanvien);
            _context.SaveChanges();
        }

        // PUT api/nhanvien/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] NhanVien nhanvien)
        {
            var tnhanvien = _context.NhanVien.FirstOrDefault(nv => nv.manhanvien == id);
            if (tnhanvien != null)
            {
                _context.Entry<NhanVien>(tnhanvien).CurrentValues.SetValues(nhanvien);
                _context.SaveChanges();
            }
        }

        // DELETE api/nhanvien/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var nhanvien = _context.NhanVien.FirstOrDefault(nv => nv.manhanvien == id);
            if (nhanvien != null)
            {
                _context.NhanVien.Remove(nhanvien);
                _context.SaveChanges();
            }
        }
    }
}