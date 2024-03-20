//using Microsoft.AspNetCore.Http;

using RoutingExample_RouteParameter_.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);

//registering custom constraint
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
});

var app = builder.Build();

//enable Routing
app.UseRouting();

//CreatingEndpoints
app.UseEndpoints(endpoints =>
{
    //create endpoint for files/fileName.extension
    //Here fileName and extension are ROUTE Parameters as they can vary
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        //accessing Route Parameter Values
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

        await context.Response.WriteAsync($"In files - {fileName} - {extension}");
    });

    //creating second endpoint
    endpoints.Map("employee/profile/{employeename=ujjwal}", async context =>
    {
        //accessing route parameter values
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);

        await context.Response.WriteAsync($"In Employee Profile - {employeeName}");
    });

    //creating third endpoint demonstrating Route Parameter Constraints, DateTime
    endpoints.Map("daily-digest-report/{reportdate:datetime}", async context =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        await context.Response.WriteAsync($"In Daily-Digest-Report - {reportDate.ToShortDateString()}");
    });

    //creating fourth endpoint demonstrating Guid as Route Parameter Constraint
    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
        await context.Response.WriteAsync($"In City Info - {cityId}");
    });

    //creating fifth endpoint demonstrating Regex as Route Parameter Constraint
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        if(month == "apr" || month == "jul" || month == "oct" || month == "jan")
        {
            await context.Response.WriteAsync($"sales report - {year} - {month}");
        }
        else
        {
            await context.Response.WriteAsync($"{month} is not allowed for sales report - {year} - {month}");
        }
    });
});

//this is default middleware, will execute if the url is other than files
app.Run(async context =>
{
    await context.Response.WriteAsync($"No routes matched at {context.Request.Path}");
});

app.Run();
