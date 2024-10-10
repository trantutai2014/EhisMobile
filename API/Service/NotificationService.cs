using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
<<<<<<< HEAD
using System.Collections.Concurrent;
=======
<<<<<<< HEAD
using System.Collections.Concurrent;
=======
>>>>>>> b6c5cdab1ddf0d3225e469dfb9bb0120217a7777
>>>>>>> bb5dda1161ca0cc37fcdda9b32550d38f0f96b3d

namespace Service
{
  public class NotificationService
  {
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> bb5dda1161ca0cc37fcdda9b32550d38f0f96b3d
    // Store all connected WebSocket clients
    private static ConcurrentBag<WebSocket> _clients = new ConcurrentBag<WebSocket>();

    // Send notification to a specific WebSocket client
<<<<<<< HEAD
=======
=======
>>>>>>> b6c5cdab1ddf0d3225e469dfb9bb0120217a7777
>>>>>>> bb5dda1161ca0cc37fcdda9b32550d38f0f96b3d
    public async Task SendNotification(WebSocket webSocket, string notification)
    {
      var buffer = Encoding.UTF8.GetBytes(notification);
      var segment = new ArraySegment<byte>(buffer);
<<<<<<< HEAD
=======
<<<<<<< HEAD
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
=======

>>>>>>> bb5dda1161ca0cc37fcdda9b32550d38f0f96b3d
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

<<<<<<< HEAD
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
=======
      await webSocket.CloseAsync(receiveResult.CloseStatus.Value, receiveResult.CloseStatusDescription, CancellationToken.None);
>>>>>>> b6c5cdab1ddf0d3225e469dfb9bb0120217a7777
>>>>>>> bb5dda1161ca0cc37fcdda9b32550d38f0f96b3d
    }
  }
}
