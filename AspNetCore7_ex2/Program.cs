/*
 ####################################################################################################
 ####################################################################################################
 ####################################################################################################
    
    ASP.NET CORE 7 - esercizi sulla sezione 4: Middleware

 ####################################################################################################
 ####################################################################################################
 ####################################################################################################
 */

//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

/*
 E' qui che mettiamo l'application middleware.
Occhio che l'ordine è importante perchè è l'ordine di esecuzione
 */

// EX 1 SEZIONE 4: Middleware
// puoi concatenare i middleware ma non con il metodo Run!
// Run: viene usato per eseguire un "terminating/short circuiting" middleware
// che non manda la request al successivo middleware
//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Hello");
//});

//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Hello again");//non verrà eseguito
//});

// EX 2 SEZIONE 4: Middleware
// puoi concatenare i middleware con il metodo Use!

// middleware 1
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("Hello");
//    await next(context);

//    // puoi aggiungere del codice dopo il next
//    // questa codice verrà eseguito DOPO il middleware 2
//});
//// middleware 2
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("Hello again");
//    bool condition = true;
//    if (condition) // puoi chiamare il middleware 3 anche solo in una determinata condizione
//    {
//        await next(context);
//    }
//});
//// middleware 3
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("Hello again 3");
//});

// EX 3 SEZIONE 4: Middleware
// è meglio spostare i middleware in una classe
using AspNetCore7_ex2.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

// iniettiamo il middleware come service usando la dependency injection
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

//middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("From middleware 1");
    await next(context);
});
// abbiamo spostato il middleware 2 nella classe MyCustomMiddleware
//app.UseMiddleware<MyCustomMiddleware>();
// EX 4 SEZIONE 4: Middleware
// usiamo un extention per il middleware
//app.UseMyCustomMiddleware();
// EX 5 SEZIONE 4: Middleware
app.UseConventionalMiddleware();

// middleware 3
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("From middleware 3");
});



app.Run();
