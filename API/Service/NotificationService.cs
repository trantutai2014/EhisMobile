using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Service
{
  public class NotificationService
  {
    // Tạo một từ điển để lưu trữ mối quan hệ giữa CCCD và WebSocket
    private static ConcurrentDictionary<string, WebSocket> _clientSockets = new ConcurrentDictionary<string, WebSocket>();

    // Gửi thông báo đến một client WebSocket cụ thể
    public async Task SendNotification(WebSocket webSocket, string notification)
    {
      var buffer = Encoding.UTF8.GetBytes(notification);
      var segment = new ArraySegment<byte>(buffer);
      await webSocket.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
    }

    // Gửi thông báo tới tất cả các client đã kết nối
    public async Task<bool> SendNotificationToAllClients(string message)
    {
      var buffer = Encoding.UTF8.GetBytes(message);
      var segment = new ArraySegment<byte>(buffer);

      foreach (var client in _clientSockets.Values)
      {
        if (client.State == WebSocketState.Open)
        {
          await client.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
        }
      }

      return true;
    }

    // Thêm một client vào từ điển với CCCD
    public void AddClient(string cccd, WebSocket client)
    {
      _clientSockets.TryAdd(cccd, client);
    }

    // Gửi thông báo đến client theo CCCD
    public async Task<bool> SendNotificationToClientByCCCD(string cccd, string message)
    {
      // Kiểm tra xem client có tồn tại trong từ điển không
      if (_clientSockets.TryGetValue(cccd, out WebSocket client))
      {
        if (client.State == WebSocketState.Open)
        {
          var buffer = Encoding.UTF8.GetBytes(message);
          var segment = new ArraySegment<byte>(buffer);
          await client.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
          return true;
        }
      }
      // Trả về false nếu không tìm thấy client hoặc kết nối không mở
      return false;
    }

    // Nhận và chuyển tiếp thông báo cho mỗi kết nối WebSocket
    public async Task ReceiveAndForwardNotifications(WebSocket webSocket, string cccd)
    {
      // Thêm WebSocket vào từ điển với CCCD
      AddClient(cccd, webSocket);

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

      // Xóa WebSocket khỏi từ điển khi kết nối đóng
      _clientSockets.TryRemove(cccd, out _);
    }
  }
}
