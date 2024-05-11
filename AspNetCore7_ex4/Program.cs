/*
 ####################################################################################################
 ####################################################################################################
 ####################################################################################################
    
    ASP.NET CORE 7 - esercizi sulla sezione 5: Routing

 ####################################################################################################
 ####################################################################################################
 ####################################################################################################
 */
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// EX 1 SEZIONE 5: Routing
//app.UseRouting();// abilita il routing

//app.UseEndpoints(endpoints =>
//{
//    // crea gli endpoints
//    // NB: map abbina il path a tutti i metodi: GET, POST, PUT, ... 
//    // Puoi fare la richiesta in postman usando: GET, POST, PUT, ... 
//    endpoints.Map("map1", async (context) =>
//    {
//        await context.Response.WriteAsync("In map 1");
//    });

//    // crea gli endpoints
//    // Puoi fare la richiesta in postman usando solo GET
//    endpoints.MapGet("map2", async (context) =>
//    {
//        await context.Response.WriteAsync("In map 2");
//    });

//});

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync($"Request at {context.Request.Path}");
//});

// EX 2 SEZIONE 5: Routing => GetEndpoint
//app.Use(async (context, next) =>
//{
//    Endpoint? endpoint = context.GetEndpoint(); // prima del routing risponderà sempre null
//    await next(context);
//});

//app.UseRouting();// viene eseguito il routing

//app.Use(async (context, next) =>
//{
//    Endpoint? endpoint = context.GetEndpoint();// dopo del routing risponderà correttamente con l'endoint
//    await next(context);
//});

// EX 3 SEZIONE 5: Routing => route parameters
app.UseRouting();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    // {filename} e {extension} sono route parameters
    endpoints.Map("files/{filename}.{extension}", async (context) =>
    {
        string? filename = Convert.ToString(context.Request.RouteValues["filename"] );
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

        await context.Response.WriteAsync($"In files - {filename} - {extension}");
    });

    // ex: employee/profile/john
    // il default parameter è sasha, significa
    // che se non metto il name direttamente metterà come valore del paramentro sasha
    endpoints.Map("employee/profile/{name=sasha}", async (context) =>
    {
        string? name = Convert.ToString(context.Request.RouteValues["name"]);

        await context.Response.WriteAsync($"Employee - {name}");
    });

    // ex: employee/profile
    // il parameter id è opzionale, darà null
    endpoints.Map("employee/profile/{id?}", async (context) =>
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
        // la conversione darà 0
        await context.Response.WriteAsync($"Employee - {id}");
    });

    // ex: employee/profile/abc => non andrà in questo pezzo di codice
    // ex: employee/profile/1 => ok
    // il parameter id ha un constraint, può essere solo int
    endpoints.Map("employee/profile/{id:int}", async (context) =>
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
        // la conversione darà 0
        await context.Response.WriteAsync($"Employee - {id}");
    });
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Request at {context.Request.Path}");
});

app.Run();
