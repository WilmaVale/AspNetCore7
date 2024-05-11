/*
 ####################################################################################################
 ####################################################################################################
 ####################################################################################################
    
    ASP.NET CORE 7 - esercizi sulla sezione 13: Environments

 ####################################################################################################
 ####################################################################################################
 ####################################################################################################
 */

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

// puoi controllare in che ambiente sai
// e abilitare delle pagine
if (app.Environment.IsDevelopment())
{ 
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
