
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace CineVault.Controllers
{
    [ApiController]
    [ApiVersion(1.0, Deprecated = true)]
    [Route("api/v{version:apiVersion}/movies")]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(new[]
            {
                new { Id = 1, Title = "Inception" },
                new { Id = 2, Title = "Interstellar" },
                new { Id = 3, Title = "The Matrix" }
            });
        }

        [HttpGet("{id:int}")]
        public IActionResult GetMovieById(int id)
        {
            if (id <= 0)
                return BadRequest("Некоректний ID фільму");

            return Ok(new
            {
                Id = id,
                Title = "Фільм версії 1.0"
            });
        }
    }
}
