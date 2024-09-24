using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.Common.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DangNhapController : ControllerBase
    {
        private readonly DangNhapService _dangNhapService;
        private readonly IConfiguration _configuration;

        public DangNhapController(DangNhapService dangNhapService, IConfiguration configuration)
        {
            _dangNhapService = dangNhapService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
      try
      {
                var user = await _dangNhapService.LoginAsync(model.Username, model.Password);

                if (user != null)
                {
                    return Ok(new { message = "Đăng nhập thành công" });
                }
                else
                {
                    return BadRequest(new { message = "Tài khoản hoặc mật khẩu không chính xác" });
                }
            }
            catch (Exception)
      {
                return StatusCode(500, new { message = "Lỗi hệ thống" });
            }
        }
    }


}
