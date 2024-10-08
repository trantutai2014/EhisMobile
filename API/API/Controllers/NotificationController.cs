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

    [HttpGet("ws")] // Điều chỉnh route để phù hợp với RESTful convention
    public async Task<IActionResult> GetWebSocket()
    {
      if (HttpContext.WebSockets.IsWebSocketRequest)
      {
        using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
        await _notificationService.ReceiveAndForwardNotifications(webSocket);

        // Gửi thông báo chào mừng
        var message = "Welcome to the WebSocket server!";
        await webSocket.SendAsync(
            new ArraySegment<byte>(Encoding.UTF8.GetBytes(message)),
            WebSocketMessageType.Text,
            endOfMessage: true,
            cancellationToken: CancellationToken.None
        );

        // Đóng kết nối sau khi gửi thông báo
        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed", CancellationToken.None);

        return Ok(); // Trả về 200 OK nếu hoàn thành mà không có lỗi
      }
      else
      {
        return BadRequest("This endpoint only accepts WebSocket requests."); // Trả về lỗi 400 với thông báo rõ ràng
      }
    }
  }
}
