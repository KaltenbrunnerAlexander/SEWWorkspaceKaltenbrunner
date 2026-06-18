using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiBook.Services;

namespace RestApiBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly CounterService _service;
        public ValuesController(CounterService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _service.Increment();
            return Ok(new
            {
                description = "A book is a collection of written, printed, or illustrated pages usually protected by a cover."
            });
        }
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
