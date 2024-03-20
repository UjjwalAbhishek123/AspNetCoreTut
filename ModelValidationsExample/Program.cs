using ModelValidationsExample.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    //options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});

//adding XML Input Formatter
builder.Services.AddControllers().AddXmlSerializerFormatters();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();
