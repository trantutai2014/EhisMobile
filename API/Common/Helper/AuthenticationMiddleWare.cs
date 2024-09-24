using Microsoft.AspNetCore.Http;

namespace API.Helper
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/trang-chu") && !context.Request.Cookies.ContainsKey("username"))
            {
                context.Response.Redirect("/login");
                return;
            }

            await _next(context);
        }
    }
}
