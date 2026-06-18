using Microsoft.AspNetCore.Mvc;

namespace RestApiDestinations.Controllers
{
    public class Definition : Controller
    {
        private readonly ControllerContext _definition;

        public Definition (ControllerContext definition)
        {
            _definition = definition;
        }

        [HttpGet]
        public IActionResult Get()
        {
            int currentCount = _definition.Increment();
            return Ok(new
            {
                _definition = "Ein bestimmter Ort, der als Reiseziel für Erholung und Urlaub ausgewählt wird.",
                callCount = currentCount
            });
        }

        [HttpPost]
        public IActionResult Post()
        {
            return StatusCode(400, new { message = "Post auf diesen Punkt nicht erlaubt" });
        }


    }
}
