using Microsoft.AspNetCore.Mvc;
using Service;

namespace YourNamespace.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class QRCodeController : ControllerBase
  {
    private readonly IQRCodeService _qrCodeService;

    public QRCodeController(IQRCodeService qrCodeService)
    {
      _qrCodeService = qrCodeService;
    }
    [HttpGet("{cccd}")]
    public async Task<IActionResult> GetByCCCD(string cccd)
    {
      var qrCode = await _qrCodeService.GetByCCCD(cccd);
      if (qrCode == null)
      {
        return NotFound();
      }
      return Ok(qrCode);
    }
  }
}
