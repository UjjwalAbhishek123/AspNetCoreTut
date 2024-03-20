using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//calling GetEndpoint() before UseRouting() returns Null always

//app.Use(async (context, next) =>
//{
//    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
    
//    if(endpoint != null)
//    {
//        await context.Response.WriteAsync($"Endpoint: {endpoint.DisplayName}\n");
//    }
    
//    await next(context);
//});dotnet build

//Enable routing
app.UseRouting();

//Using GetEndpoint() -> Identifies the appropriate Endpoints based on incoming Request
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();

    if (endpoint != null)
    {
        await context.Response.WriteAsync($"Endpoint: {endpoint.DisplayName}\n");
    }

    await next(context);
});

//Defining actual endpoints/middleware
app.UseEndpoints(endpoints =>
{
    //add your endpoints
    endpoints.Map("map1", async (context) =>
    {
        await context.Response.WriteAsync("In Map1");
    });

    endpoints.Map("map2", async (context) =>
    {
        await context.Response.WriteAsync("In Map2");
    });

    //adding endpoints for Http GET method only
    //endpoints.MapGet("map3", async (context) =>
    //{
    //    await context.Response.WriteAsync("In Map3, Only GET request..");
    //});

    ////adding endpoints for Http POST method only
    endpoints.MapPost("map4", async (context) =>
    {
        await context.Response.WriteAsync("In Map4, Only POST request..");
    });
});

//if the request is received other than map1, map2
app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
