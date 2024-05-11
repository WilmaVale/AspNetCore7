/*
 ####################################################################################################
 ####################################################################################################
 ####################################################################################################
    
    ASP.NET CORE 7 - esercizi sulla sezione 6: Controllers & IActionResult

 ####################################################################################################
 ####################################################################################################
 ####################################################################################################
 */

var builder = WebApplication.CreateBuilder(args);

// EX 1 SEZIONE 6: Controllers & IActionResult
// aggiunge tutte le controller classes (classi che finiscono con Controller)
// come servizi  in IServiceCollection
builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();

//app.UseRouting();
//#pragma warning disable ASP0014 // Suggest using top level route registrations
//app.UseEndpoints(endpoints =>
//{
//    // mappa i controllers con il routing
//    endpoints.MapControllers();
//});
//#pragma warning restore ASP0014 // Suggest using top level route registrations

// mappa i controllers chiamando UseEndpoints e MapControllers
// aggiunge tutti gli action methods come endpoints
app.MapControllers();

app.Run();
