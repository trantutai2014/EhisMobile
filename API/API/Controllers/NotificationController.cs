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

<<<<<<< HEAD
    [HttpGet("ws")]
=======
<<<<<<< HEAD
    [HttpGet("ws")]
=======
    [HttpGet("ws")] // Điều chỉnh route để phù hợp với RESTful convention
>>>>>>> b6c5cdab1ddf0d3225e469dfb9bb0120217a7777
>>>>>>> bb5dda1161ca0cc37fcdda9b32550d38f0f96b3d
    public async Task<IActionResult> GetWebSocket()
    {
      if (HttpContext.WebSockets.IsWebSocketRequest)
      {
        using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
        await _notificationService.ReceiveAndForwardNotifications(webSocket);
<<<<<<< HEAD
        return Ok(); // WebSocket connection established
=======
<<<<<<< HEAD
        return Ok(); // WebSocket connection established
      }
      else
      {
        return BadRequest("This endpoint only accepts WebSocket requests.");
      }
    }

    // New API endpoint to send a message from API to client
    [HttpPost("send")]
    public async Task<IActionResult> SendNotification([FromBody] string message)
    {
      var result = await _notificationService.SendNotificationToAllClients(message);
      if (result)
        return Ok("Message sent to WebSocket clients");
      return StatusCode(500, "Failed to send message to WebSocket clients");
    }
=======

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
>>>>>>> bb5dda1161ca0cc37fcdda9b32550d38f0f96b3d
      }
      else
      {
        return BadRequest("This endpoint only accepts WebSocket requests.");
      }
    }
<<<<<<< HEAD

    // New API endpoint to send a message from API to client
    [HttpPost("send")]
    public async Task<IActionResult> SendNotification([FromBody] string message)
    {
      var result = await _notificationService.SendNotificationToAllClients(message);
      if (result)
        return Ok("Message sent to WebSocket clients");
      return StatusCode(500, "Failed to send message to WebSocket clients");
    }
=======
>>>>>>> b6c5cdab1ddf0d3225e469dfb9bb0120217a7777
>>>>>>> bb5dda1161ca0cc37fcdda9b32550d38f0f96b3d
  }
}
