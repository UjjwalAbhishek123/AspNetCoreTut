var builder = WebApplication.CreateBuilder(args);

//adding controllers as service
builder.Services.AddControllers();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//enabling Static Files
app.UseStaticFiles();

//enabling Routing
app.UseRouting();

//adding endpoints for all controllers
app.MapControllers();

app.Run();
