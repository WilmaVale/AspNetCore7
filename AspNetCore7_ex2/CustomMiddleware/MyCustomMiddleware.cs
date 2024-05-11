// EX 3 SEZIONE 4: Middleware
// è meglio spostare i middleware in una classe

namespace AspNetCore7_ex2.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My custom middleware - starts\n");
            await next(context);
            await context.Response.WriteAsync("My custom middleware - ends\n");
        }
    }

    // EX 4 SEZIONE 4: Middleware
    // extension method
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware
            ( this IApplicationBuilder app)
        { 
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
