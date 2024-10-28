using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Data.EF;
using System.Reflection;
using NetCore.AutoRegisterDi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Service;
using Common.Model;
using Common.Helpers;
using Microsoft.OpenApi.Models;
using System.Net.WebSockets;

var builder = WebApplication.CreateBuilder(args);

// CORS Configuration
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowLocalNetwork", policy =>
  {
    policy.WithOrigins("http://localhost:8100", "https://192.168.0.106")
          .AllowAnyHeader()
          .AllowAnyMethod()
          .SetIsOriginAllowed(_ => true) // Allow any origin
          .AllowCredentials();  // Required for WebSocket over CORS
  });
});


// JWT Authentication Setup
var key = Encoding.UTF8.GetBytes("D8a%6Pz#bQ9x^1vZ3rR4k@tF6vU5eJ7!nM8jH3wD2zQ9bC7uA5eR9gT4wJ1lX8haaaa");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = true,
        ClockSkew = TimeSpan.Zero,
        ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha512 }
      };
    });

// WebSocket Configuration
var webSocketOptions = new WebSocketOptions
{
  KeepAliveInterval = TimeSpan.FromMinutes(2),
  AllowedOrigins = { "http://localhost:8100", "https://192.168.0.106" }
};

// Authorization and Controllers Setup
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger Setup
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
});

// Database Setup
builder.Services.AddDbContext<MDPDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MDPDevConnection")));

// Service Registration
builder.Services.AddScoped<UserRoleService, UserRoleService>();
builder.Services.AddScoped<DangNhapService, DangNhapService>();
builder.Services.AddScoped<DangKyService, DangKyService>();
builder.Services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();
builder.Services.AddScoped<PasswordHelper, PasswordHelper>();
builder.Services.AddScoped(typeof(IRepository), typeof(Repository));
builder.Services.AddScoped<QRCodeService, QRCodeService>();
builder.Services.AddScoped<ThongTinService, ThongTinService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<NotificationService, NotificationService>();
builder.Services.AddScoped<HoSoService, HoSoService>();
builder.Services.AddScoped<SkdtHoSoService4210, SkdtHoSoService4210>();
builder.Services.AddScoped<SkdtHoSo130Service, SkdtHoSo130Service>();
var assembliesToScan = new[] { Assembly.GetAssembly(typeof(IUserRoleService)) };

builder.Services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
    .Where(c => c.Name.EndsWith("Service"))
    .AsPublicImplementedInterfaces();

var app = builder.Build();

// Development Environment Setup
if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseSwagger();
  app.UseSwaggerUI();
}
else
{
  app.UseHttpsRedirection();
}

// Middleware Setup
app.UseWebSockets(); // Place before Authentication/Authorization
app.UseCors("AllowLocalNetwork");
app.UseAuthentication();
app.UseAuthorization();


// WebSocket Mapping for Notifications
app.Map("/api/Notification/ws", async (HttpContext context) =>
{
  if (context.WebSockets.IsWebSocketRequest)
  {
    var webSocket = await context.WebSockets.AcceptWebSocketAsync();
    await HandleWebSocketCommunication(webSocket);
  }
  else
  {
    context.Response.StatusCode = 400; // Bad Request if not WebSocket
  }
});

app.MapControllers();
app.Run();

// WebSocket Handler Logic
async Task HandleWebSocketCommunication(WebSocket webSocket)
{
  var buffer = new byte[1024 * 4];
  WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

  while (!result.CloseStatus.HasValue)
  {
    // Echo back the received message
    await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);

    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
  }

  await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
}
