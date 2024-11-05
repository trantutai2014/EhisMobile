using API.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace YourNamespace.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  public class ThongTinController : ControllerBase
  {
    private readonly IThongTinService _ThongTinService;
    private readonly TokenService _tokenService;
    private readonly HoSoService _hoSoService;

    // Constructor
    public ThongTinController(IThongTinService ThongTinService, TokenService tokenService, HoSoService hoSoService)
    {
      _ThongTinService = ThongTinService;
      _tokenService = tokenService; // Khởi tạo _tokenService
      _hoSoService = hoSoService; // Khởi tạo _hoSoService
    }

    [HttpGet("{cccd}")]
    public async Task<IActionResult> GetByCode(string cccd)
    {
      var skdt_HoSo = await _ThongTinService.GetByCCCD(cccd);
      if (skdt_HoSo != null)
      {
        return Ok(new { Data = MapQR.MapLoginQR(skdt_HoSo, _hoSoService) });
      }

      return NotFound("Không tìm thấy thông tin.");
    }
  }
}
