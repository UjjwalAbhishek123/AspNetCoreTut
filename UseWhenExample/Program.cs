var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen(
    //context here is the condition, if it is true then next statement i.e. "app" will execute
    context => context.Request.Query.ContainsKey("username"),
    app =>
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Hello From middleware branch");
            await next();
        });
    });

//If the above condition is not true, following middleware will execute
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello From middleware at main chain");
});

app.Run();
