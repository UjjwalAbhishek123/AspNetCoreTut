using AutofacDependencyInjectionServiceContracts;
using AutofacDependencyInjectionService;
using Autofac.Extensions.DependencyInjection;
using Autofac;

var builder = WebApplication.CreateBuilder(args);

//Enabling AutoFac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


//adding controller with views as service
builder.Services.AddControllersWithViews();

//registering Scope to Autofac
builder.Host.ConfigureContainer<ContainerBuilder>(
    containerBuilder =>
    {
        //Equivalent to AddTransient
        //containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency();

        //Equivalent to AddScoped
        containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope();

        //Equivalent to AddSingleton
        //containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().SingleInstance();
    }
    );

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