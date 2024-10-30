using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Service;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NotificationController : ControllerBase
  {
    private readonly NotificationService _notificationService;

    private readonly MDPDbContext _context;

    public NotificationController(NotificationService notificationService, MDPDbContext context)
    {
      _notificationService = notificationService;
      _context = context;

    }

    [HttpDelete]
    [Route("{cccd}")]
    public async Task<IActionResult> DeleteThongBaoByCccd( string cccd)
    {
      var thongBaos = await _context.ThongBaos
          .Where(tb => tb.UserId == cccd)
          .ToListAsync();

      // removeRange để xóa danh sách
      _context.RemoveRange(thongBaos);
      _context.SaveChangesAsync();

      return Ok();
    }

    [HttpGet("{cccd}")]
    public async Task<IActionResult> GetThongBaoByCccd([FromRoute] string cccd)
    {
      var thongBaos = await _context.ThongBaos
          .Where(tb => tb.UserId == cccd)
          .ToListAsync();

      return Ok(thongBaos);
    }


    [HttpGet("ws/{cccd}")]
    public async Task<IActionResult> GetWebSocket(string cccd)
    {
      if (HttpContext.WebSockets.IsWebSocketRequest)
      {
        using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();

        // Gọi phương thức nhận và chuyển tiếp thông báo, liên kết WebSocket với CCCD
        await _notificationService.ReceiveAndForwardNotifications(webSocket, cccd);
        return Ok(); // WebSocket connection established
      }
      else
      {
        return BadRequest("This endpoint only accepts WebSocket requests.");
      }
    }

    // API để gửi thông báo từ API tới tất cả các client WebSocket
    [HttpPost("send")]
    public async Task<IActionResult> SendNotification([FromBody] string message)
    {
      var result = await _notificationService.SendNotificationToAllClients(message);
      if (result)
        return Ok("Message sent to WebSocket clients");
      return StatusCode(500, "Failed to send message to WebSocket clients");
    }

    // API để gửi thông báo từ API tới client dựa trên CCCD
    [HttpPost("sendByCccd")]
    public async Task<IActionResult> SendNotificationByCccd([FromBody] NotificationRequest request)
    {
      var result = await _notificationService.SendNotificationToClientByCCCD(request.Cccd, request.Message);
      if (result)
      {
        var thongBaoModel = new ThongBao
        {
          Id = Guid.NewGuid().ToString(), // Tạo mới GUID cho Id
          UserId = request.Cccd,
          Content = request.Message,
          DateCreated = DateTime.Now,
          Title = "Thông báo của hệ thống!"
        };
        await _context.ThongBaos.AddAsync(thongBaoModel);
        await _context.SaveChangesAsync();
        return Ok(thongBaoModel);
        // return Ok("Message sent to WebSocket client with CCCD: " + request.Cccd);
      }
      else
      {
        return StatusCode(500, "Failed to send message to WebSocket client with CCCD: " + request.Cccd);

      }
    }

    // cập nhật trạng thái xem thông báo
    [HttpPost("updateAllIsView")]
    public async Task<IActionResult> UpdateAllIsView()
    {
      // Lấy tất cả các bản ghi trong bảng ThongBaos
      var thongBaos = await _context.ThongBaos.ToListAsync();

      if (thongBaos.Count > 0)
      {
        // Cập nhật IsView = true cho tất cả các bản ghi
        foreach (var thongBao in thongBaos)
        {
          thongBao.IsView = true;
        }

        // Lưu thay đổi vào cơ sở dữ liệu
        await _context.SaveChangesAsync();

        return Ok();
      }
      else
      {
        return NotFound("No records found to update.");
      }
    }

  }

  // Class để nhận dữ liệu từ yêu cầu POST
  public class NotificationRequest
  {
    public string? Cccd { get; set; }
    public string? Message { get; set; }
  }
}
