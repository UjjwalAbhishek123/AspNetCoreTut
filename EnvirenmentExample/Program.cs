var builder = WebApplication.CreateBuilder(args);

//adding controller with views as service
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Checking Environment
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//enabling static files
app.UseStaticFiles();

//enabling routing
app.UseRouting();

//enabling endpoints for all controllers
app.MapControllers();

app.Run();