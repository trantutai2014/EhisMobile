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

var builder = WebApplication.CreateBuilder(args);

// Configure CORS to allow credentials
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAngularApp",
      policy =>
      {
        policy.WithOrigins("http://localhost:8100") // Adjust as needed
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
      });
});

// JWT Authentication
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

var webSocketOptions = new WebSocketOptions
{
  KeepAliveInterval = TimeSpan.FromMinutes(2)
};

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger setup
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "API",
    Version = "v1"
  });
});

// Database configuration
builder.Services.AddDbContext<MDPDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MDPDevConnection")));

// Service registration
builder.Services.AddScoped<UserRoleService, UserRoleService>();
builder.Services.AddScoped<DangNhapService, DangNhapService>();
builder.Services.AddScoped<DangKyService, DangKyService>();
builder.Services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();
builder.Services.AddScoped<PasswordHelper, PasswordHelper>();
builder.Services.AddScoped(typeof(IRepository), typeof(Repository));
builder.Services.AddScoped<QRCodeService, QRCodeService>();
builder.Services.AddScoped<ThongTinService, ThongTinService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<NotificationService, NotificationService>(); // Fix for NotificationService registration
builder.Services.AddScoped<SkdtHoSoService4210>();
builder.Services.AddScoped<SkdtHoSo130Service>();


var assembliesToScan = new[]
{
    Assembly.GetAssembly(typeof(IUserRoleService))
};

builder.Services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
        .Where(c => c.Name.EndsWith("Service"))
        .AsPublicImplementedInterfaces();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseSwagger();
  app.UseSwaggerUI();

}
else
{
  app.UseWebSockets(webSocketOptions);
}

app.UseCors("AllowAngularApp");
app.UseAuthentication();
app.UseAuthorization();
app.UseWebSockets(webSocketOptions);

app.MapControllers();
app.Run();
