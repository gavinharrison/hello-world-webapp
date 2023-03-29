using Microsoft.AspNetCore.Mvc.Formatters;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // To allow the catchall controller to read the raw body content.
            app.Use((context, next) => {
                context.Request.EnableBuffering();
                return next(context);
            });

            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}