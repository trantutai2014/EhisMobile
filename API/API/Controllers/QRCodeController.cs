using API.Mapper;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace YourNamespace.Controllers
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

    //[HttpGet("{cccd}")]
    //public async Task<IActionResult> GetByCCCD(string cccd)
    //{
    //  var qrCodeData = await _qrCodeService.GetByCCCD(cccd);

    //  if (qrCodeData != null)
    //  {
    //    // Generate the token
    //    var token = _tokenService.GenerateToken(cccd);

    //    // Return the QR code data and token
    //    return Ok(new { qrCodeData, token });
    //  }

    //  return NotFound("Không tìm thấy thông tin.");
    //}


    [HttpGet("{code}")]
    public async Task<IActionResult> GetByCode(string code)
    {
      var skdt_HoSo = await _qrCodeService.GetByCode(code);
      if (skdt_HoSo != null)
      {
        ///var token = _tokenService.GenerateToken(skdt_HoSo);
        return Ok(MapQR.MapLoginQR(skdt_HoSo));
      }

      return NotFound("Không tìm thấy thông tin.");
    }

  }
}
