using Microsoft.AspNetCore.Mvc;
using MovieBack.Business;
using MovieBack.Model;

namespace MovieBack.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController()
        {
            _movieService = new MovieService();
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _movieService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] Movie movie)
        {
            var createdMovie = _movieService.CreateMovie(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = createdMovie.Id }, createdMovie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie movie)
        {
            var updatedMovie = _movieService.UpdateMovie(id, movie);
            if (updatedMovie == null)
            {
                return NotFound();
            }
            return Ok(updatedMovie);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var result = _movieService.DeleteMovie(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
