using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using API.Services;
using API.Model;
using Data.EF;
using System.Reflection;
using NetCore.AutoRegisterDi;

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
builder.Services.AddScoped<API.Helper.PasswordHelper, API.Helper.PasswordHelper>();
builder.Services.AddScoped(typeof(IRepository), typeof(Repository));
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
}else
{
    // For mobile apps, allow http traffic.
    app.UseHttpsRedirection();
}


app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowAngularApp");

// Use Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
