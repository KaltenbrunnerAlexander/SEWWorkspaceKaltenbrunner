using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Models;

namespace RazorPagesMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Connection String aus der appsettings.json auslesen
            var connectionString = builder.Configuration.GetConnectionString("RazorPagesMovieContext")
                ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.");

            // 2. Datenbank-Kontext registrieren (Zwingend UseSqlite statt UseSqlServer!)
            builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
                options.UseSqlite(connectionString));

            // 3. Razor Pages Benutzeroberflächen-Dienste hinzufügen
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // 4. HTTP-PIPELINE KONFIGURIEREN
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // 5. Razor Pages Endpunkte aktivieren
            app.MapRazorPages();

            app.Run();
        }
    }
}