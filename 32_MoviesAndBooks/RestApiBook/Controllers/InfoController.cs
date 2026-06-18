// NEU (Aufgabe 1a, 1b, 1d): InfoController für den /info-Endpunkt
using Microsoft.AspNetCore.Mvc;
using RestApiBook.Services;

namespace RestApiBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        // AUFGABE 1d: CounterService per Dependency Injection
        private readonly ICounterService _counterService;

        public InfoController(ICounterService counterService)
        {
            _counterService = counterService;
        }

        // AUFGABE 1a: GET /info → JSON mit Buchbeschreibung
        // AUFGABE 1d: Zähler bei jedem Aufruf um 1 erhöhen
        [HttpGet]
        public IActionResult Get()
        {
            int currentCount = _counterService.Increment();
            return Ok(new
            {
                description = "A book is a collection of written, printed, or illustrated pages usually protected by a cover.",
                callCount = currentCount
            });
        }

        // AUFGABE 1b: POST /info → beliebiger HTTP Status Code
        [HttpPost]
        public IActionResult Post()
        {
            return StatusCode(202, new { message = "POST request received with status 202 Accepted" });
        }
    }
}
