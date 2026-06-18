// GEÄNDERT: Program.cs wurde erweitert um:
// - SQLite Datenbank für Bücher (Aufgabe 1c)
// - CounterService als Singleton (Aufgabe 1d)

// NEU: Using-Direktiven für Entity Framework und den BookContext
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

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // AUFGABE 1c: SQLite Datenbank für Bücher registrieren
            // Die Datenbankdatei wird als "books.db" im Projektverzeichnis erstellt.
            // Normalerweise würde die Connection String in appsettings.json stehen,
            // aber für SQLite reicht diese einfache Konfiguration direkt im Code.
            builder.Services.AddDbContext<BookContext>(options =>
                options.UseSqlite("Data Source=books.db"));

            // AUFGABE 1d: CounterService als Singleton registrieren
            // Singleton bedeutet: Es gibt genau eine Instanz des Services
            // für die gesamte Laufzeit der Anwendung.
            // Bei Server-Neustart wird eine neue Instanz erstellt → Zähler startet bei 0.
            builder.Services.AddSingleton<ICounterService, CounterService>();

            var app = builder.Build();

            // AUFGABE 1c: Datenbank beim Start automatisch erstellen/migrieren
            // Stellt sicher, dass die Datenbank und alle Tabellen existieren.
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BookContext>();
                db.Database.EnsureCreated(); // Erstellt die Datenbank falls sie nicht existiert
            }

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
