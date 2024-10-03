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

var builder = WebApplication.CreateBuilder(args);



// Configure CORS to allow credentials
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:8100") // Replace with your Angular app's URL
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});
// Thêm JWT Authentication
// Khóa bí mật của bạn
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
            ClockSkew = TimeSpan.Zero, // Tùy chọn giảm thiểu độ trễ thời gian
            ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha512 } // Sử dụng thuật toán HS512
        };
    });

// Đăng ký TokenService với DI container
builder.Services.AddScoped<TokenService>(); // Hoặc AddSingleton(), AddTransient() tùy theo phạm vi sử dụng


builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Entity Framework and other services
builder.Services.AddDbContext<MDPDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MDPDevConnection")));

builder.Services.AddScoped<UserRoleService, UserRoleService>();
builder.Services.AddScoped<DangNhapService, DangNhapService>();
builder.Services.AddScoped<DangKyService, DangKyService>();
builder.Services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();
builder.Services.AddScoped<PasswordHelper, PasswordHelper>();
builder.Services.AddScoped(typeof(IRepository), typeof(Repository));
builder.Services.AddScoped<QRCodeService, QRCodeService>();
builder.Services.AddScoped<ThongTinService, ThongTinService>();
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
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    // For mobile apps, allow http traffic.
    //app.UseHttpsRedirection();
}


//app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowAngularApp");

// Use Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
