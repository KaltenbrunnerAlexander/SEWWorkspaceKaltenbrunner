// GEÄNDERT: SQLite-Datenbank (1c) + CounterService als Singleton (1d)
using Microsoft.EntityFrameworkCore;
using RestApiBook.Data;
using RestApiBook.Services;

namespace RestApiBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // AUFGABE 1c: SQLite-Datenbank für Bücher registrieren
            builder.Services.AddDbContext<BookContext>(options =>
                options.UseSqlite("Data Source=books.db"));

            // AUFGABE 1d: CounterService als Singleton registrieren
            // Singleton = eine Instanz pro Server-Laufzeit → Zähler startet bei Neustart bei 0
            builder.Services.AddSingleton<ICounterService, CounterService>();

            var app = builder.Build();

            // AUFGABE 1c: Datenbank + Tabellen beim Start automatisch erstellen
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BookContext>();
                db.Database.EnsureCreated();
            }

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
