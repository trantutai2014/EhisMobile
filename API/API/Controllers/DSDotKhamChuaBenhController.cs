using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DSDotKhamChuaBenhController : ControllerBase
    {
        private readonly MDPDbContext _context;


        public DSDotKhamChuaBenhController(MDPDbContext context)
        {
            _context = context;
        }


        [HttpGet("{cccd}")]
        public async Task<ActionResult<ThongTinKhamChuaBenh130>> GetThongTinDSDotKhamChuaBenhByCccd(string cccd)
        {
            var result = await _context.ThongTinKhamChuaBenh130s
                .Where(x => x.SO_CCCD.Contains(cccd)) // Tìm kiếm theo CCCD
                .FirstOrDefaultAsync(); // Lấy giá trị đầu tiên

            if (result == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy kết quả
            }

            return Ok(new { Data = result }); // Trả về kết quả
        }


    }
}
