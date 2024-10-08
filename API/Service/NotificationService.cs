
//using System.Collections.Concurrent;
//using System.Threading.Tasks;

//public class NotificationService
//{
//  private readonly SocketIoServer _socketIo;
//  private readonly ConcurrentDictionary<string, SocketIoSocket> _connectedUsers;

//  public NotificationService()
//  {
//    _socketIo = new SocketIoServer(new ServerOptions());
//    _connectedUsers = new ConcurrentDictionary<string, SocketIoSocket>();
//  }

//  public void Configure()
//  {
//    _socketIo.OnConnect((socket) =>
//    {
//      // Assuming the client sends the user ID immediately after connecting
//      socket.On("register_user", (userId) =>
//      {
//        _connectedUsers.TryAdd(userId, socket);
//        Console.WriteLine($"User {userId} connected.");
//      });

//      socket.OnDisconnect(() =>
//      {
//        var user = _connectedUsers.FirstOrDefault(x => x.Value == socket);
//        if (user.Key != null)
//        {
//          _connectedUsers.TryRemove(user.Key, out _);
//          Console.WriteLine($"User {user.Key} disconnected.");
//        }
//      });
//    });
//  }

//  // Send notification to a specific user by their ID
//  public async Task SendNotificationToUser(string userId, string message)
//  {
//    if (_connectedUsers.TryGetValue(userId, out var socket))
//    {
//      await socket.EmitAsync("notification", message);
//    }
//  }
//}
