using API.Mapper;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace YourNamespace.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ThongTinController : ControllerBase
  {
    private readonly IThongTinService _ThongTinService;
    private readonly TokenService _tokenService;

    public ThongTinController(IThongTinService ThongTinService, TokenService tokenService)
    {
      _ThongTinService = ThongTinService;
    }
    [HttpGet("{cccd}")]
    public async Task<IActionResult> GetByCode(string cccd)
    {
      var skdt_HoSo = await _ThongTinService.GetByCCCD(cccd);
      if (skdt_HoSo != null)
      {
        return Ok(new { Data = (MapQR.MapLoginQR(skdt_HoSo))});
      }

      return NotFound("Không tìm thấy thông tin.");
    }

  }
}
