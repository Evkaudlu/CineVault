
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace CineVault.Controllers
{
    [ApiController]
    [ApiVersion(2.0)]
    [Route("api/v{version:apiVersion}/movies")]
    public class MoviesV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(new[]
            {
                new
                {
                    Id = 1,
                    Title = "Inception",
                    Genre = "Science Fiction",
                    Year = 2010,
                    Rating = 8.8
                },
                new
                {
                    Id = 2,
                    Title = "Interstellar",
                    Genre = "Science Fiction",
                    Year = 2014,
                    Rating = 8.7
                },
                new
                {
                    Id = 3,
                    Title = "The Matrix",
                    Genre = "Science Fiction",
                    Year = 1999,
                    Rating = 8.7
                }
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
                Title = "Фільм версії 2.0",
                Genre = "Science Fiction",
                Year = 2024,
                Rating = 9.0
            });
        }
    }
}
