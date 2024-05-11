/*
 ####################################################################################################
 ####################################################################################################
 ####################################################################################################
    
    ASP.NET CORE 7 - esercizi sulla sezione 14: Configuration

 ####################################################################################################
 ####################################################################################################
 ####################################################################################################

Ex 1: interrogare un server per vedere in tempo reale gli Stocks
 */

using AspNetCore7_ex10.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// aggiungi il http client
builder.Services.AddHttpClient();
// aggiungi il servizio
builder.Services.AddScoped<FinnHubService>();


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
