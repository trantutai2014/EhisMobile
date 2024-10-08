using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Service;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
      _tokenService = tokenService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(DateTime.Now);
    }
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
    {
      var newAccessToken = await _tokenService.RefreshToken(refreshToken);

      if (newAccessToken == null)
      {
        return Unauthorized();
      }

      return Ok(new { accessToken = newAccessToken });
    }
  }
}
