using System.Runtime.CompilerServices;

namespace MiddlewareExample.CustomMiddleware
{
    //Custom Middleware class will always inherit the IMiddleware Interface to get registered as a middleware
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //before logic
            await context.Response.WriteAsync(" My Custom Middleware - Starts\n");

            //Invoking next middleware
            await next(context);

            //after logic
            await context.Response.WriteAsync(" My Custom Middleware - Ends\n");
        }
    }

    //Creating Extension Method
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
