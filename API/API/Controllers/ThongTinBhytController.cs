using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Mapper;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThongTinBhytController : ControllerBase
    {

        private readonly MDPDbContext _context;

        public ThongTinBhytController(MDPDbContext context)
        {
            _context = context;
        }

        [HttpGet("{cccd}")]
        public async Task<ActionResult<IEnumerable<ThongTinKhamChuaBenh130>>> GetThongTinBhytByCccd(string cccd)
        {
            var result = await _context.ThongTinKhamChuaBenh130s
                .Where(x => x.SO_CCCD.Contains(cccd)) // Tìm kiếm theo tên
                .ToListAsync();

            if (result == null || !result.Any())
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy kết quả
            }

            // return Ok(new { Data = ThongTinBhytMapper.ThongTinBhytMap(result) }); // Trả về danh sách kết quả

            return Ok(new { Data = result.Select(r => ThongTinBhytMapper.ThongTinBhytMap(r)).ToList() });

        }

    }
}
