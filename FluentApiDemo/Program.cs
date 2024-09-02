using FluentApiDemo.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Registering The FluentValidation

//1. enables integration between FluentValidation and Asp.Net mvc's automatic validation pipeline
builder.Services.AddFluentValidationAutoValidation();

//2. enables integration between FluentValidation and Asp.Net client-side validation.
builder.Services.AddFluentValidationClientsideAdapters();

//3. Registering model and Validator to show the error messsage on client side
builder.Services.AddTransient<IValidator<RegistrationModel>, RegistrationValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Register}/{id?}");

app.Run();
