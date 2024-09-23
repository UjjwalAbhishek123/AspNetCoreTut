using CodeFirstEFcoreAspNetCore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//creating service for ConnectionString and Register it
//var provider = builder.Services.BuildServiceProvider();
//var config = provider.GetRequiredService<IConfiguration>();
//builder.Services.AddDbContext<StudentDbContext>(
//        item => item.UseSqlServer(config.GetConnectionString("DbConcStr"))
//        );

//Above way can also be used to register Service for ConnectionString,
//but,
//calling BuildServiceProvider() directly creates an additional copy of singleton services, which is not a recommended practice in ASP.NET Core. Instead of manually building the service provider and resolving services like IConfiguration, you can avoid this by directly accessing the builder.Configuration property in the new ASP.NET Core Program.cs file.

//You don't need to manually call BuildServiceProvider() or resolve the IConfiguration service. ASP.NET Core's WebApplicationBuilder already provides direct access to configuration via "builder.Configuration".

//    By avoiding BuildServiceProvider(), the singleton lifecycle is correctly managed by ASP.NET Core. Services like IConfiguration and DbContext will behave as expected without creating multiple instances.

//So use below way always, recommended by asp.net core

// Access the connection string directly from builder.Configuration
builder.Services.AddDbContext<StudentDbContext>( options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DbConcStr"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
