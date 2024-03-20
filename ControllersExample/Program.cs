using ControllersExample.Controllers;

var builder = WebApplication.CreateBuilder(args);

//adding controllers as a service
//for single controller -> builder.Services.AddTransient<HomeController>();

//for multiple ccontrollers
builder.Services.AddControllers(); //It adds all the controller class as Service

var app = builder.Build();

//enabling StaticFiles
app.UseStaticFiles();

//enable routing
app.UseRouting();

//creating endpoint
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

 app.MapControllers();

app.Run();
