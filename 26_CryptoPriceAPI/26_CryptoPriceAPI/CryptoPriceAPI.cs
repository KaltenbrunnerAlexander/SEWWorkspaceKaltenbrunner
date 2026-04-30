using System.ComponentModel.DataAnnotations;
    
namespace _26_CryptoPriceAPI;

    // --- MODEL ---
    public class CryptoPrice
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty; 
        public decimal CurrentPrice { get; set; }
       
        public DateTime Timestamp { get; set; }
       
    }

    // --- DATENBANK KONTEXT ---
    public class CryptoDbContext : DbContext
    {
        public CryptoDbContext(DbContextOptions<CryptoDbContext> options) : base(options) { }
        public DbSet<CryptoPrice> CryptoPrices { get; set; } = null!; 
    }

// --- GENERATOR SERVICE ---
public class PriceGeneratorService
{
    private readonly IServiceProvider _serviceProvider;
    private bool _isRunning = false;
    private Timer? _timer;
    private readonly Random _random = new();

    public PriceGeneratorService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Start()
    {
        if (_isRunning) return;
        _isRunning = true;
        _timer = new Timer(GeneratePrice, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
    }

    public void Stop()
    {
        _timer?.Change(Timeout.Infinite, 0);
        _isRunning = false;
    }

    private async void GeneratePrice(object? state)
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CryptoDbContext>();

        var lastEntry = await context.CryptoPrices.OrderByDescending(p => p.Timestamp).FirstOrDefaultAsync();
        decimal lastPrice = lastEntry?.CurrentPrice ?? 100.0m; 
        
        // Maximal 5% Abweichung vom letzten Kurs 
        decimal change = (decimal)(_random.NextDouble() * 0.1 - 0.05);
        decimal newPrice = lastPrice * (1 + change);

        var newEntry = new CryptoPrice
        {
            Name = "HTLCoin",
            CurrentPrice = Math.Round(newPrice, 2),
            Timestamp = DateTime.Now
        };

        context.CryptoPrices.Add(newEntry);
        await context.SaveChangesAsync();

        // Konsolenausgabe wie im Screenshot gefordert 
        Console.WriteLine($">>>> Neuer Kurs hinzugefügt: {newEntry.Name} - {newEntry.CurrentPrice} USD");
    }
}

