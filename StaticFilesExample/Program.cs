//recognizing "myroot" folder as webroot
var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "myroot"
});
var app = builder.Build();

//enable static Files
app.UseStaticFiles();

//enable routing
app.UseRouting();

//creating Endpoint
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync("Hello");
    });
});

app.Run();
