using Microsoft.AspNetCore.Mvc;

namespace RestApiBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly CounterService _counterService;

        // Hier wird der CounterService injiziert
        public InfoController(CounterService counterService)
        {
            _counterService = counterService;
        }

        // a) GET /info
        [HttpGet]
        public IActionResult GetInfo()
        {
            _counterService.Increment(); // c) Erhöht den Zähler bei jedem Aufruf

            return Ok(new { description = "A book is a collection of written, printed, or illustrated pages usually protected by a cover." });
        }

        // b) POST /info
        [HttpPost]
        public IActionResult PostInfo()
        {
            return Accepted(new { message = "Status Code 202 - Accepted" });
        }
    }
}
