using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Primitives;

namespace Assignment1.CustomMiddlewareAssignment
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //checking if the request path and request method are "/", and "POST"
            if(context.Request.Path == "/" && context.Request.Method == "POST")
            {
                //Reading request body of POST method
                StreamReader reader = new StreamReader(context.Request.Body);
                string body = await reader.ReadToEndAsync();

                //Parsing the request body from Query String to Dictionary
                Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

                String? email = null, password = null;

                //reading email if submitted in request body
                if (queryDict.ContainsKey("email"))
                {
                    email = Convert.ToString(queryDict["email"][0]);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'email'\n");
                }

                //reading password if submitted in request body
                if (queryDict.ContainsKey("password"))
                {
                    password = Convert.ToString(queryDict["password"][0]);
                }
                else
                {
                    if (context.Response.StatusCode == 200)
                    {
                        context.Response.StatusCode = 400;
                    }
                    await context.Response.WriteAsync("Invalid input for 'password'\n");
                }

                //If both email and password are submitted in the request
                if (string.IsNullOrEmpty(email) == false && string.IsNullOrEmpty(password) == false)
                {
                    //valid email and password as per the requirement
                    string validEmail = "admin@example.com", validPassword = "admin1234";
                    
                    //to check if login is valid as per the credentials
                    bool isValidLogin;

                    //if email and password are valid
                    isValidLogin = (email == validEmail && password == validPassword) ? true : false;

                    /********************* or can be done as *********************/
                    //if (email == validEmail && password == validPassword)
                    //{
                    //    isValidLogin = true;
                    //}
                    //else
                    //{
                    //    isValidLogin = false;
                    //}

                    //send response
                    if (isValidLogin)
                    {
                        await context.Response.WriteAsync("Successful Login\n");
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid Login\n");
                    }
                }
            }
            else
            {
                await _next(context);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
