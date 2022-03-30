using System;
using MarketAPI.Entity;
using MarketAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using System.Web.Http.Cors;

namespace MarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GianHangController : ControllerBase
    {
        private readonly ModelContext _context;
        public GianHangController(ModelContext context)
        {
            _context = context;
        }

        //GET api/gianhang
        [HttpGet]
        public IEnumerable<GianHang> DangSachGianHang()
        {
            return _context.GianHang.ToList();
        }

        //GET api/gianhang/id
        [HttpGet("{id}")]
        public GianHang GetGianHangByMaGH(string id)
        {
            return _context.GianHang.FirstOrDefault(gh => gh.magianhang == id);
        }
        //GET api/gianhang/doanhthu/magianhang/day/month/year
        [HttpGet("doanhthu/{magianhang}/{day}/{month}/{year}")]
        public IEnumerable<DoanhThu> GetDoanhThu(string magianhang, string day, string month, string year)
        {
            string t = "select * from TinhDoanhThu('" + magianhang + "'," + day + "," + month + "," + year + ") order by doanhthu desc";
            return _context.DoanhThu.FromSql(t);
        }
        //GET api/gianhang/tongquandoanhthu/magianhang/year
        [HttpGet("tongquandoanhthu/{magianhang}/{year}")]
        public IEnumerable<TongQuanDoanhThu> GetTongQuanDoanhThu(string magianhang, string year)
        {
            string t = "select * from TongQuanDoanhThu('" + magianhang + "'," + year + ")";
            return _context.TongQuanDoanhThu.FromSql(t);
        }
        //GET api/gianhang/ngh_gannhat/{id}
        [HttpGet("ngh_gannhat/{id}")]
        public IEnumerable<NguoiGiaoHang> NguoiGiaoHangGanNhat(string id)
        {
            var ngh = _context.NguoiGiaoHang.ToList();
            var gh = _context.GianHang.FirstOrDefault(x => x.magianhang == id);

            List<NguoiGiaoHang> nearby = new List<NguoiGiaoHang>();

            if (gh == null)
                return nearby.DefaultIfEmpty();

            if (ngh.Any())
            {
                foreach (var item in ngh)
                {

                    string phuongxa = "";
                    phuongxa = (item.phuongxa_ngh == null ? "" : item.phuongxa_ngh);

                    string quanhuyen = "";
                    quanhuyen = (item.quanhuyen_ngh == null ? "" : item.quanhuyen_ngh);

                    string thanhpho = "";
                    thanhpho = (item.thanhpho_ngh == null ? "" : item.thanhpho_ngh);

                    string phuongxa_gh = "";
                    phuongxa_gh = (gh.phuongxa_gh == null ? "!" : gh.phuongxa_gh);

                    string quanhuyen_gh = "";
                    quanhuyen_gh = (gh.quanhuyen_gh == null ? "!" : gh.quanhuyen_gh);

                    string thanhpho_gh = "";
                    thanhpho_gh = (gh.thanhpho_gh == null ? "!" : gh.thanhpho_gh);

                    if (phuongxa == phuongxa_gh && quanhuyen == quanhuyen_gh && thanhpho == thanhpho_gh)
                    {
                        nearby.Add(item);
                    }

                    if (phuongxa != phuongxa_gh && quanhuyen == quanhuyen_gh && thanhpho == thanhpho_gh)
                    {
                        nearby.Add(item);
                    }
                }

                if (!nearby.Any())
                {
                    foreach (var item in ngh)
                    {
                        string thanhpho = "";
                        thanhpho = (item.thanhpho_ngh == null ? "" : item.thanhpho_ngh);

                        string thanhpho_gh = "";
                        thanhpho_gh = (gh.thanhpho_gh == null ? "!" : gh.thanhpho_gh);

                        if (thanhpho == thanhpho_gh)
                        {
                            nearby.Add(item);
                        }
                    }
                }
            }
            return !nearby.Any() ? nearby.DefaultIfEmpty() : nearby;
        }

        
        //GET api/gianhang/giayto/magianhang/loaigiayto
        [HttpGet("giayto/{magianhang}/{loaigiayto}")]
        public IEnumerable<GiayTo> GetGiayTo(string magianhang,string loaigiayto)
        {
            string t = "select * from GIAYTO where gianhang='"+magianhang+"'";
            if(loaigiayto!="All")
            {
                t = t + " and loaigiayto=N'" + loaigiayto + "'";
            }    

            return _context.GiayTo.FromSql(t);
        }
        // POST api/gianhang
        [HttpPost]
        public void Post([FromBody] GianHang gianhang)
        {
            _context.GianHang.Add(gianhang);
            _context.SaveChanges();
        }

        
        // PUT api/gianhang/5
        [HttpPut("{id}")]
        public void ChinhSuaThongTinGianHang(string id, [FromBody] GianHang gianhang)
        {
            var tgianhang = _context.GianHang.FirstOrDefault(nv => nv.magianhang == id);
            if (tgianhang != null)
            {
                ///_context.Entry<GianHang>(tgianhang).CurrentValues.SetValues(gianhang);
                tgianhang.tengianhang = gianhang.tengianhang;
                tgianhang.sonha_gh = gianhang.sonha_gh;
                tgianhang.phuongxa_gh = gianhang.phuongxa_gh;
                tgianhang.quanhuyen_gh = gianhang.quanhuyen_gh;
                tgianhang.thanhpho_gh = gianhang.thanhpho_gh;
                tgianhang.motagianhang = gianhang.motagianhang;
                tgianhang.sdt_gh = gianhang.sdt_gh;
                tgianhang.email_gh = gianhang.email_gh;
                _context.SaveChanges();
            }
        }

        // PUT api/gianhang/doimatkhau
        [HttpPut("doimatkhau/{id}")]
        public void DoiMatKhauGianHang(string id, [FromBody] GianHang gianhang)
        {
            var tgianhang = _context.GianHang.FirstOrDefault(nv => nv.magianhang == id);
            if (tgianhang != null)
            {
                tgianhang.matkhau = gianhang.matkhau;
                _context.SaveChanges();
            }
        }

        // PUT api/gianhang/nghiban
        [HttpPut("nghiban/{id}")]
        public void GianHangNghiBan(string id)
        {
            var tgianhang = _context.GianHang.FirstOrDefault(nv => nv.magianhang == id);
            if (tgianhang != null)
            {
                tgianhang.tinhtranggianhang = "Nghỉ bán";
                _context.SaveChanges();
            }
        }

        // DELETE api/gianhang/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var gianhang = _context.GianHang.FirstOrDefault(nv => nv.magianhang == id);
            if (gianhang != null)
            {
                _context.GianHang.Remove(gianhang);
                _context.SaveChanges();
            }
        }

        //GET api/gianhang/vungdo
        [HttpGet("vungdo")]
        public List<GianHang> GianHangVungDo()
        {
            string query = "select * from GIANHANG gh where exists(select * from VUNG where gh.PhuongXa_GH = VUNG.PhuongXa and gh.QuanHuyen_GH = VUNG.QuanHuyen and vung.LoaiVung = N'Vùng đỏ')";
            return _context.GianHang.FromSql(query).ToList();
        }

        //GET api/gianhang/vungvang
        [HttpGet("vungvang")]
        public List<GianHang> GianHangVungVang()
        {
            string query = "select * from GIANHANG gh where exists(select * from VUNG where gh.PhuongXa_GH = VUNG.PhuongXa and gh.QuanHuyen_GH = VUNG.QuanHuyen and vung.LoaiVung = N'Vùng vàng')";
            return _context.GianHang.FromSql(query).ToList();
        }

        //GET api/gianhang/vungxanh
        [HttpGet("vungxanh")]
        public List<GianHang> GianHangVungXanh()
        {
            string query = "select * from GIANHANG gh where exists(select * from VUNG where gh.PhuongXa_GH = VUNG.PhuongXa and gh.QuanHuyen_GH = VUNG.QuanHuyen and vung.LoaiVung = N'Vùng xanh')";
            return _context.GianHang.FromSql(query).ToList();
        }
    }
}

