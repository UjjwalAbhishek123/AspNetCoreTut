var builder = WebApplication.CreateBuilder(args);

//adding controllers as service
builder.Services.AddControllers();
var app = builder.Build();

//Enabling Static Files
app.UseStaticFiles();

//enabling routing
app.UseRouting();

//adding endpoints for all controllers
app.MapControllers();

app.Run();
