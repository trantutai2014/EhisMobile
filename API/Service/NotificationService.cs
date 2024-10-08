using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
  public class NotificationService
  {
    public async Task SendNotification(WebSocket webSocket, string notification)
    {
      var buffer = Encoding.UTF8.GetBytes(notification);
      var segment = new ArraySegment<byte>(buffer);

      await webSocket.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
    }

    public async Task ReceiveAndForwardNotifications(WebSocket webSocket)
    {
      var buffer = new byte[1024 * 4];
      var receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

      while (!receiveResult.CloseStatus.HasValue)
      {
        // Example: Forwarding the received data back as a notification
        var receivedMessage = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
        await SendNotification(webSocket, $"Notification: {receivedMessage}");

        receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
      }

      await webSocket.CloseAsync(receiveResult.CloseStatus.Value, receiveResult.CloseStatusDescription, CancellationToken.None);
    }
  }
}
