using _28_WebAPI_Example.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _28_WebAPI_Example.Controllers
{

    //Endpoint /api/DateTime
    // --> liefert das aktuelle Datum (als JSON)
    public class DateTimeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetDateTime()
        {
            string dateTime = DateTime.Now.ToString();
            return Ok(new {DateTime = dateTime});
        }
    }
}
