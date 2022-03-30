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
    public class UuDaiController : ControllerBase
    {
        private readonly ModelContext _context;
        public UuDaiController(ModelContext context)
        {
            _context = context;
        }

        //GET api/uudai
        [HttpGet]
        public IEnumerable<UuDai> Get()
        {
            return _context.UuDai.ToList();
        }

        //GET api/uudai/UD23443
        [HttpGet("{id}")]
        public UuDai GetUuDai(string id)
        {
            return _context.UuDai.FirstOrDefault(ud => ud.mauudai == id);
        }

        //GET api/uudai/UD23443
        [HttpGet("kiemtra/{id}")]
        public int CheckUuDai(string id)
        {
            return _context.UuDai.Count(ud => ud.mauudai == id);
        }
    }
}