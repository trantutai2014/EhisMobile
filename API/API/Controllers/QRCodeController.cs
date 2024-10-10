using API.Mapper;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class QRCodeController : ControllerBase
  {
    private readonly IQRCodeService _qrCodeService;
    private readonly TokenService _tokenService;

    public QRCodeController(IQRCodeService qrCodeService, TokenService tokenService)
    {
      _qrCodeService = qrCodeService;
      _tokenService = tokenService;
    }
    [HttpGet("{code}")]
    public async Task<IActionResult> GetByCode(string code)
    {
      var skdt_HoSo = await _qrCodeService.GetByCode(code);

      if (skdt_HoSo != null)
      {
        var token = _tokenService.GenerateTokens(skdt_HoSo.CCCD);
        return Ok(new { CCCD = skdt_HoSo.CCCD, Token = token });
      }
      return NotFound("Không tìm thấy thông tin.");
    }
  }
}
