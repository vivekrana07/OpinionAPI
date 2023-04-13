using Microsoft.AspNetCore.Mvc;
using OpinionAPI.Context;
using OpinionAPI.Interface;
using OpinionAPI.Model;

namespace OpinionAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class MoviesController : Controller
    {
        private readonly IMovies _movies;
        public MoviesController(IMovies movies)
        {
            _movies = movies;
        }

        [HttpPost("AddMovie")]
        public Task<ActionResult> AddMovie([FromForm] AddMoviesContext Movies)
        {
            var result = _movies.AddMovie(Movies);
            return result;
        }

        [HttpGet("GetMovie")]
        public List<Movies> GetMovies()
        {
            var result = _movies.GetMovies();
            return result;
        }

        [HttpPost("AddRating")]
        public Task<ActionResult> AddRating([FromBody] RatingContext ratingContext)
        {
            var result = _movies.AddRating(ratingContext);
            return result;
        }
    }
}
