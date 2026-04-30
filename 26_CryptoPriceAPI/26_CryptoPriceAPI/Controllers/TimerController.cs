using Microsoft.AspNetCore.Mvc;

namespace _26_CryptoPriceAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimerController : ControllerBase
{
    private readonly PriceGeneratorService _gen;
    private readonly ILogger<TimerController> _logger; 

    public TimerController(PriceGeneratorService gen, ILogger<TimerController> logger)
    {
        _gen = gen;
        _logger = logger;
    }

    
    [HttpPost("Start")] // Startet den Timer [cite: 48]
    public IActionResult Start()
    {
        _gen.Start();
        _logger.LogInformation("Timer gestartet."); 
        return Ok();
    }

    
    [HttpPost("Stop")] // Stoppt den Timer [cite: 47]
    public IActionResult Stop()
    {
        _gen.Stop();
        _logger.LogInformation("Timer gestoppt."); 
        return Ok();
    }
}