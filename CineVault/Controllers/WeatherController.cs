
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace CineVault.Controllers
{
    [ApiController]
    [ApiVersion(1.0, Deprecated = true)]
    [ApiVersion(2.0)]
    [Route("api/v{version:apiVersion}/weather")]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion(1.0)]
        public IActionResult GetV1()
        {
            return Ok("Погода v1 — стара модель");
        }

        [HttpGet]
        [MapToApiVersion(2.0)]
        public IActionResult GetV2()
        {
            return Ok(new
            {
                Temp = 25,
                Forecast = "Сонячно",
                Unit = "Celsius"
            });
        }
    }
}
