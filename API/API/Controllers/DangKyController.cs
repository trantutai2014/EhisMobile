using API.Common.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class DangKyController : ControllerBase
{
    private readonly DangKyService _userService;

    public DangKyController(DangKyService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _userService.RegisterAsync(model);
            return Ok(new { message = "Đăng ký thành công" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Đã xảy ra lỗi trong quá trình đăng ký", details = ex.Message });
        }
    }
}
