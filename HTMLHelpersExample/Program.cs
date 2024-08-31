var builder = WebApplication.CreateBuilder(args);

//adding controller to service
builder.Services.AddControllersWithViews();

var app = builder.Build();

//enabling static files
app.UseStaticFiles();

//enabling routing
app.UseRouting();

//enabling endpoints for all controllers
app.MapControllers();

app.Run();