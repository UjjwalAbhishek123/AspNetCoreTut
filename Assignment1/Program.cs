using Assignment1.CustomMiddlewareAssignment;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Invoking Custom Middleware
app.UseLoginMiddleware();

//app.MapGet("/", () => "Hello World!");
app.Run(async context =>
{
    await context.Response.WriteAsync("No Response");
});
app.Run();
