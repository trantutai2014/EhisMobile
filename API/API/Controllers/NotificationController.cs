using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Service;
using System.Text;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NotificationController : ControllerBase
  {
    private readonly NotificationService _notificationService;

    public NotificationController(NotificationService notificationService)
    {
      _notificationService = notificationService;
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
        return Ok("Message sent to WebSocket client with CCCD: " + request.Cccd);
      return StatusCode(500, "Failed to send message to WebSocket client with CCCD: " + request.Cccd);
    }
  }

  // Class để nhận dữ liệu từ yêu cầu POST
  public class NotificationRequest
  {
    public string Cccd { get; set; }
    public string Message { get; set; }
  }
}
