using AutofacDependencyInjectionServiceContracts;
using AutofacDependencyInjectionService;
using Autofac.Extensions.DependencyInjection;
using Autofac;

var builder = WebApplication.CreateBuilder(args);

//NEW => enabling AUTOFAC
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//adding controller with views as service
builder.Services.AddControllersWithViews();

//NEW => ADD SERVICES TO AUTOFAC
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuider =>
{
    //containerBuider.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency();
    //Equiv to AddTransient<>()

    containerBuider.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope();
    //Equiv to AddScoped<>()

    //containerBuider.RegisterType<CitiesService>().As<ICitiesService>().SingleInstance();
    //Equiv to AddSingleton<>()
});

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