/*
 ####################################################################################################
 ####################################################################################################
 ####################################################################################################
    
    ASP.NET CORE 7 - esercizi sulla sezione 3: HTTP

 ####################################################################################################
 ####################################################################################################
 ####################################################################################################
 */

using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    // EX 1 SEZIONE 3: HTTP
    //bool test = true;
    //if (test)
    //{
    //    context.Response.StatusCode = 200;
    //}
    //else
    //{
    //    context.Response.StatusCode = 400;
    //}

    // EX 2 SEZIONE 3: HTTP
    // gli Headers della risposta sono un dizionario chiave-valore
    //context.Response.Headers["addedKey"] = "value";
    //context.Response.Headers["server"] = "My server";
    //context.Response.Headers["Content-Type"] = "text/html";

    //await context.Response.WriteAsync("<h1>Hello</h1>");
    //await context.Response.WriteAsync("<h2>World</h2>");

    // EX 3 SEZIONE 3: HTTP
    // puoi guardare i dati della richiesta
    //string path = context.Request.Path;
    //string method = context.Request.Method;
    //context.Response.Headers["Content-Type"] = "text/html";
    //await context.Response.WriteAsync($"<p>Path: {path}</p>");
    //await context.Response.WriteAsync($"<p>Method: {method}</p>");

    // EX 4 SEZIONE 3: HTTP
    // leggere valori dalla query string della richiesta
    //context.Response.Headers["Content-Type"] = "text/html";
    //if (context.Request.Method == "GET")
    //{
    //    if (context.Request.Query.ContainsKey("id"))
    //    {
    //        string id = context.Request.Query["id"];
    //        await context.Response.WriteAsync($"<p>Query id: {id}</p>");
    //    }
    //}

    // EX 5 SEZIONE 3: HTTP
    // leggere il body di un richiesta POST
    StreamReader reader = 
    new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    Dictionary<string, StringValues> queryDict
        = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
    if (context.Request.Query.ContainsKey("id"))
    {
        string firstName = queryDict["firstName"][0];
        await context.Response.WriteAsync($"<p>Body firstName: {firstName}</p>");
    }
});

app.Run();
