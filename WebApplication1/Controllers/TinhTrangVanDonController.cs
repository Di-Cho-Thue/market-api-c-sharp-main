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
    public class TinhTrangVanDonController : ControllerBase
    {
        private readonly ModelContext _context;

        public TinhTrangVanDonController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/TinhTrangVanDon
        [HttpGet]
        public IEnumerable<TinhTrangVanDon> GetTinhTrangVanDon()
        {
            return _context.TinhTrangVanDon;
        }

        // GET: api/TinhTrangVanDon/5
        [HttpGet("{id}")]
        public ActionResult GetTinhTrangVanDon([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<TinhTrangVanDon> tinhTrangVanDon = _context.TinhTrangVanDon.AsNoTracking().Where(x => x.madonhang == id).ToList();

            if (tinhTrangVanDon == null)
            {
                return NotFound();
            }

            return Ok(tinhTrangVanDon);
        }

        // PUT: api/TinhTrangVanDon/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTinhTrangVanDon([FromRoute] string id, [FromBody] TinhTrangVanDon tinhTrangVanDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tinhTrangVanDon.madonhang)
            {
                return BadRequest();
            }

            _context.Entry(tinhTrangVanDon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TinhTrangVanDonExists(id))
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

        // POST: api/TinhTrangVanDon
        [HttpPost]
        public async Task<IActionResult> PostTinhTrangVanDon([FromBody] TinhTrangVanDon tinhTrangVanDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TinhTrangVanDon.Add(tinhTrangVanDon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTinhTrangVanDon", new { id = tinhTrangVanDon.madonhang }, tinhTrangVanDon);
        }

        // DELETE: api/TinhTrangVanDon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTinhTrangVanDon([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tinhTrangVanDon = await _context.TinhTrangVanDon.FindAsync(id);
            if (tinhTrangVanDon == null)
            {
                return NotFound();
            }

            _context.TinhTrangVanDon.Remove(tinhTrangVanDon);
            await _context.SaveChangesAsync();

            return Ok(tinhTrangVanDon);
        }

        private bool TinhTrangVanDonExists(string id)
        {
            return _context.TinhTrangVanDon.Any(e => e.madonhang == id);
        }
    }
}