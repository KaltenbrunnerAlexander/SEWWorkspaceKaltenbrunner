var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// EF-InMemory-Datenbank registrieren [cite: 3]
builder.Services.AddDbContext<_26_CryptoPriceAPI.CryptoDbContext>(opt =>
    opt.UseInMemoryDatabase("CryptoDb"));

// Generator als Singleton registrieren
builder.Services.AddSingleton<_26_CryptoPriceAPI.PriceGeneratorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
