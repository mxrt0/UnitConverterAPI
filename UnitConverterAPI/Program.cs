using UnitConverterAPI.Models;

namespace UnitConverterAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IConverterRepository, UnitConverterRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
