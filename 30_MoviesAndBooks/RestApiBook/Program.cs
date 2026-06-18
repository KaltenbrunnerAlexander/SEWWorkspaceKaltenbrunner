using Microsoft.EntityFrameworkCore;
using RestApiBook.Services;
namespace RestApiBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("RestApiBookContext") ?? throw new InvalidOperationException("Connection string 'RestApiBookContext' not found.");

            builder.Services.AddDbContext<RestApiBookContext>(options => options.UseSqlite(connectionString));

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSingleton<CounterService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
