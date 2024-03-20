using Microsoft.Extensions.Primitives;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run(async(HttpContext context) =>
{
    /* ------ Accessing Response Objects ------ */
    //context.Response.StatusCode = 500; //status code for response

    /* ------  Response Header ------ */
    //context.Response.Headers["MyKey"] = "my value";

    //await context.Response.WriteAsync("<h1>Hello</h1>");
    //await context.Response.WriteAsync(" World");

    /* ------ Http Requests ------ */
    //string path = context.Request.Path; //give path present in request URL
    //string method = context.Request.Method; //gives the request method GET/POST
    //context.Response.Headers["Content-Type"] = "text/html";

    //await context.Response.WriteAsync($"<p>{path}</p>");
    //await context.Response.WriteAsync($"<p>{method}</p>");

    //context.Response.Headers["Content-Type"] = "text/html";
    ////checking if request method is GET
    //if (context.Request.Method == "GET")
    //{
    //    //if above condition is True, then checking if the Query contains key named "id"
    //    if (context.Request.Query.ContainsKey("id"))
    //    {
    //        //if above condition is also true, then reading the value of Key "id"
    //        string id = context.Request.Query["id"];
    //        await context.Response.WriteAsync($"<p>{id}</p>");
    //    }
    //}

    //context.Response.Headers["Content-Type"] = "text/html";
    ////checking if request headers contains particular key
    //if (context.Request.Headers.ContainsKey("User-Agent"))
    //{
    //    //reading the User-Agent request Header value
    //    string userAgent = context.Request.Headers["User-Agent"];
    //    await context.Response.WriteAsync($"<p>{userAgent}</p>");
    //}

    //reading the requested body for POST method in asp.net core
    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync(); //it will asynchronously load the full request body

    Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
    if (queryDict.ContainsKey("firstName"))
    {
        string firstName = queryDict["firstName"][0];//reading the FirstName if firstName Key exist

        //reading multiple firstNames
        foreach (var names in queryDict["firstName"])
        {
            await context.Response.WriteAsync(names + " "); //generating HTTP response
        }
        //await context.Response.WriteAsync(firstName); //generating HTTP response
    }
});

app.Run();
