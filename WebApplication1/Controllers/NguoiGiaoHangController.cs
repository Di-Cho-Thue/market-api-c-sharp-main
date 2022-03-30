using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketAPI.Entity;
using MarketAPI.Models;

namespace MarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiGiaoHangController : ControllerBase
    {
        private readonly ModelContext _context;

        public NguoiGiaoHangController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/NguoiGiaoHang
        [HttpGet]
        public IEnumerable<NguoiGiaoHang> GetNguoiGiaoHang()
        {
            return _context.NguoiGiaoHang;
        }

        // GET: api/NguoiGiaoHang/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNguoiGiaoHang([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nguoiGiaoHang = await _context.NguoiGiaoHang.FindAsync(id);

            if (nguoiGiaoHang == null)
            {
                return NotFound();
            }

            return Ok(nguoiGiaoHang);
        }

        // PUT: api/NguoiGiaoHang/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguoiGiaoHang([FromRoute] string id, [FromBody] NguoiGiaoHang nguoiGiaoHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nguoiGiaoHang.manguoigiaohang)
            {
                return BadRequest();
            }

            _context.Entry(nguoiGiaoHang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiGiaoHangExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NguoiGiaoHang
        [HttpPost]
        public async Task<IActionResult> PostNguoiGiaoHang([FromBody] NguoiGiaoHang nguoiGiaoHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.NguoiGiaoHang.Add(nguoiGiaoHang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNguoiGiaoHang", new { id = nguoiGiaoHang.manguoigiaohang }, nguoiGiaoHang);
        }

        // DELETE: api/NguoiGiaoHang/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNguoiGiaoHang([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nguoiGiaoHang = await _context.NguoiGiaoHang.FindAsync(id);
            if (nguoiGiaoHang == null)
            {
                return NotFound();
            }

            _context.NguoiGiaoHang.Remove(nguoiGiaoHang);
            await _context.SaveChangesAsync();

            return Ok(nguoiGiaoHang);
        }

        private bool NguoiGiaoHangExists(string id)
        {
            return _context.NguoiGiaoHang.Any(e => e.manguoigiaohang == id);
        }

        //GET api/nguoigiaohang/vungdo
        [HttpGet("vungdo")]
        public List<NguoiGiaoHang> NguoiGianHangVungDo()
        {
            string query = "select * from NGUOIGIAOHANG ngh where exists(select * from VUNG where ngh.PhuongXa_NGH = VUNG.PhuongXa and ngh.QuanHuyen_NGH = VUNG.QuanHuyen and vung.LoaiVung = N'Vùng đỏ')";
            return _context.NguoiGiaoHang.FromSql(query).ToList();
        }

        //GET api/nguoigiaohang/vungvang
        [HttpGet("vungvang")]
        public List<NguoiGiaoHang> NguoiGianHangVungVang()
        {
            string query = "select * from NGUOIGIAOHANG ngh where exists(select * from VUNG where ngh.PhuongXa_NGH = VUNG.PhuongXa and ngh.QuanHuyen_NGH = VUNG.QuanHuyen and vung.LoaiVung = N'Vùng vàng')";
            return _context.NguoiGiaoHang.FromSql(query).ToList();
        }

        //GET api/nguoigiaohang/vungxanh
        [HttpGet("vungxanh")]
        public List<NguoiGiaoHang> NguoiGianHangVungXanh()
        {
            string query = "select * from NGUOIGIAOHANG ngh where exists(select * from VUNG where ngh.PhuongXa_NGH = VUNG.PhuongXa and ngh.QuanHuyen_NGH = VUNG.QuanHuyen and vung.LoaiVung = N'Vùng xanh')";
            return _context.NguoiGiaoHang.FromSql(query).ToList();
        }
    }
}