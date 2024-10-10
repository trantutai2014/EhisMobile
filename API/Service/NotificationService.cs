using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Service
{
  public class NotificationService
  {
    // Store all connected WebSocket clients
    private static ConcurrentBag<WebSocket> _clients = new ConcurrentBag<WebSocket>();

    // Send notification to a specific WebSocket client
    public async Task SendNotification(WebSocket webSocket, string notification)
    {
      var buffer = Encoding.UTF8.GetBytes(notification);
      var segment = new ArraySegment<byte>(buffer);
      await webSocket.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
    }

    // Send notification to all connected clients
    public async Task<bool> SendNotificationToAllClients(string message)
    {
      var buffer = Encoding.UTF8.GetBytes(message);
      var segment = new ArraySegment<byte>(buffer);

      foreach (var client in _clients)
      {
        if (client.State == WebSocketState.Open)
        {
          await client.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
        }
      }

      return true;
    }

    // Receive and forward notifications for each WebSocket connection
    public async Task ReceiveAndForwardNotifications(WebSocket webSocket)
    {
      _clients.Add(webSocket); // Add new WebSocket client to the list

      var buffer = new byte[1024 * 4];
      WebSocketReceiveResult receiveResult;

      while (webSocket.State == WebSocketState.Open)
      {
        receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

        if (receiveResult.MessageType == WebSocketMessageType.Close)
        {
          await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
        }
        else
        {
          var receivedMessage = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
          await SendNotification(webSocket, $"Received: {receivedMessage}");
        }
      }

      _clients.TryTake(out webSocket); // Remove client when closed
    }
  }
}
