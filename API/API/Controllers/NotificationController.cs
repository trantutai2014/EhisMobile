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

    [HttpGet("ws")]
    public async Task<IActionResult> GetWebSocket()
    {
      if (HttpContext.WebSockets.IsWebSocketRequest)
      {
        using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
        await _notificationService.ReceiveAndForwardNotifications(webSocket);
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
  }
}
