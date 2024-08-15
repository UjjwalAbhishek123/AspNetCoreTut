using DependencyInjection2ServiceContracts;
using DependencyInjection2Service;

var builder = WebApplication.CreateBuilder(args);

//adding controller with views as service
builder.Services.AddControllersWithViews();

//add service through IoC Container
//builder.Services => acts as IoC Container
//it tells that, whenever some class asks for ICitiesService object, create and supply object of CitiesService
builder.Services.Add(new ServiceDescriptor(
    typeof(ICitiesService),
    typeof(CitiesService),
    ServiceLifetime.Transient
    ));

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