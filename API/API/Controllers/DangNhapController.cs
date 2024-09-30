using Microsoft.AspNetCore.Mvc;
using Service;

namespace API.Controllers
{
  [ApiController]
    [Route("api/[controller]")]
    public class DangNhapController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly DangNhapService _dangNhapService;
        private readonly IConfiguration _configuration;

        public DangNhapController(TokenService tokenService, DangNhapService dangNhapService, IConfiguration configuration)
        {
            _dangNhapService = dangNhapService;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var user = await _dangNhapService.LoginAsync(model.Username, model.Password);

                if (user != null)
                {
                    var token = _tokenService.GenerateToken(model.Username);
                    return Ok(new { token });
                    // return Ok(new { message = "Đăng nhập thành công" });
                }
                else
                {
                    return BadRequest(new { message = "Tài khoản hoặc mật khẩu không chính xác" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Lỗi hệ thống: {ex.Message}" });
            }
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
