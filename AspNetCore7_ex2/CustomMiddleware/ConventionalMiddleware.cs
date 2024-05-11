// EX 5 SEZIONE 4: Middleware
// conventional middleware

namespace AspNetCore7_ex2.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ConventionalMiddleware
    {
        private readonly RequestDelegate _next;

        public ConventionalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("firstname") &&
                context.Request.Query.ContainsKey("lastname"))
            {
                string fullname = context.Request.Query["firstname"] + " " +context.Request.Query["lastname"];
                await context.Response.WriteAsync(fullname);
            }
            await _next(context);
            // puoi scrivere codice anche dopo il _next
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    // Creato automaticamente quando crei la classe
    public static class ConventionalMiddlewareExtensions
    {
        public static IApplicationBuilder UseConventionalMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConventionalMiddleware>();
        }
    }
}
