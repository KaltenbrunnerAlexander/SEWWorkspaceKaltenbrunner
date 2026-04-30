using Microsoft.AspNetCore.Mvc;

namespace _26_CryptoPriceAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CryptoPricesController : ControllerBase
{
    private readonly CryptoDbContext _context;
    public CryptoPricesController(CryptoDbContext context) => _context = context;

    [HttpGet("Latest20")] // Liefert die letzten 20 Werte 
    public async Task<ActionResult> GetLatest20() =>
        Ok(await _context.CryptoPrices.OrderByDescending(p => p.Timestamp).Take(20).ToListAsync());

    [HttpGet("Count")] // Liefert die Anzahl 
    public async Task<ActionResult<int>> GetCount() => await _context.CryptoPrices.CountAsync();

    [HttpGet] // Liefert alle Werte 
    public async Task<ActionResult> GetAll() => Ok(await _context.CryptoPrices.ToListAsync());

    
    [HttpPost] // Speichert neuen Wert 
    public async Task<ActionResult> Post(CryptoPrice price)
    {
        _context.CryptoPrices.Add(price);
        await _context.SaveChangesAsync();
        return Ok(price);
    }

    
    [HttpGet("{id}")] // Liefert nach ID 
    public async Task<ActionResult> GetById(int id) => Ok(await _context.CryptoPrices.FindAsync(id));

    
    [HttpPut("{id}")] // Ändert nach ID 
    public async Task<IActionResult> Put(int id, CryptoPrice price)
    {
        _context.Entry(price).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    
    [HttpDelete("{id}")] // Löscht nach ID 
    public async Task<IActionResult> Delete(int id)
    {
        var p = await _context.CryptoPrices.FindAsync(id);
        if (p == null) return NotFound();
        _context.CryptoPrices.Remove(p);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}