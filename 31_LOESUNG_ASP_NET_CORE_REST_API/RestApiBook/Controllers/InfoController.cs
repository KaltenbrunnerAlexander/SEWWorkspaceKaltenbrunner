// NEU HINZUGEFÜGT (Aufgabe 1a, 1b, 1d): InfoController
// Stellt den /info Endpunkt bereit.

using Microsoft.AspNetCore.Mvc;
using RestApiBook.Services;

namespace RestApiBook.Controllers
{
    [ApiController]
    // ÄNDERUNG: Route ist explizit "info" (nicht vom Controller-Namen abgeleitet)
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        // AUFGABE 1d: CounterService wird per Dependency Injection injiziert
        private readonly ICounterService _counterService;

        // Konstruktor - CounterService wird von ASP.NET Core automatisch injiziert
        public InfoController(ICounterService counterService)
        {
            _counterService = counterService;
        }

        // AUFGABE 1a: GET /info
        // Gibt eine JSON-Antwort mit der Beschreibung eines Buches zurück.
        // AUFGABE 1d: Bei jedem Aufruf wird der Zähler um 1 erhöht.
        [HttpGet]
        public IActionResult Get()
        {
            // Zähler bei jedem GET-Aufruf erhöhen (Aufgabe 1d)
            int currentCount = _counterService.Increment();

            // Gibt das geforderte JSON-Objekt zurück (Aufgabe 1a)
            return Ok(new
            {
                description = "A book is a collection of written, printed, or illustrated pages usually protected by a cover.",
                // Optional: aktuellen Zählerstand mitgeben (zeigt dass Zähler funktioniert)
                callCount = currentCount
            });
        }

        // AUFGABE 1b: POST /info
        // Sendet eine Antwort mit einem beliebigen HTTP Status Code zurück.
        // Hier wird 202 Accepted verwendet (könnte auch jeder andere Code sein).
        [HttpPost]
        public IActionResult Post()
        {
            // Beliebiger HTTP Status Code - hier 202 Accepted als Beispiel
            // Andere Möglichkeiten wären z.B.: StatusCode(418) für "I'm a teapot", 
            // Ok() für 200, Created() für 201, etc.
            return StatusCode(202, new { message = "POST request received with status 202 Accepted" });
        }
    }
}
