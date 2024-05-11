/*
 ####################################################################################################
 ####################################################################################################
 ####################################################################################################
    
    ASP.NET CORE 7 - altri esercizi sulla sezione 4: Middleware

 ####################################################################################################
 ####################################################################################################
 ####################################################################################################
 */

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// EX 5 SEZIONE 4: Middleware
// utilizzo UseWhen
app.UseWhen(
    context => context.Request.Query.ContainsKey("username"),
    app => {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Hello form middleware branch");
            await next();
        });
    });

app.Run(async context =>
{
await context.Response.WriteAsync("Hello form middleware at main chain");
});

app.Run();
