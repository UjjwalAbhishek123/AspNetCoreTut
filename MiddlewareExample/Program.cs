using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

//Registering middleware as Service
builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

//Middleware :- A Component that is added in the application pipeline to handle response and requests

/* Creating Middleware */

//Middleware1
app.Use(async(HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("From Middleware 1\n");

    //calling next middleware
    await next(context);
});

//Middleware2
app.Use(async(HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello Again\n");

    //calling next middleware
    await next(context);
});

//app.UseMiddleware<MyCustomMiddleware>(); //Using CustomMiddleware with an extension method
app.UseMyCustomMiddleware();
app.UseHelloCustomMiddleware();

//Middleware3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync(" From Middleware 3\n");
});

app.Run();
