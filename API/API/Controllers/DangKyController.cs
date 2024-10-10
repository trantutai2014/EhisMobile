using Common.Model;
using Data.EF;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;
using Service;

[ApiController]
[Route("[controller]")]
public class DangKyController : ControllerBase
{
  private readonly DangKyService _userService;
  private readonly IUnitOfWork _unitOfWork;

  public DangKyController(DangKyService userService, IUnitOfWork unitOfWork)
  {
    _userService = userService;
    _unitOfWork = unitOfWork;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterModel model)
  {
    //if (!ModelState.IsValid)
    //{
    //  return BadRequest(ModelState);
    //}

    //try
    //{
    //  await _userService.RegisterAsync(model);
    //  return Ok(new { message = "Đăng ký thành công" });
    //}
    //catch (Exception ex)
    //{
    //  return StatusCode(500, new { message = "Đã xảy ra lỗi trong quá trình đăng ký", details = ex.Message });
    //}
    var data = await _userService.RegisterAsync(model);
    return Ok(data);
  }
}
