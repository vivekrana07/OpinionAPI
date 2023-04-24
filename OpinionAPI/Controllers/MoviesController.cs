using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost("AddMovie")]
        public Task<ActionResult> AddMovie([FromForm] AddMoviesContext Movies)
        {
            var result = _movies.AddMovie(Movies);
            return result;
        }

        [Authorize]
        [HttpGet("GetMovie")]
        public List<Movies> GetMovies()
        {
            var result = _movies.GetMovies();
            return result;
        }

        [Authorize]
        [HttpPost("AddRating")]
        public Task<ActionResult> AddRating([FromBody] RatingContext ratingContext)
        {
            var result = _movies.AddRating(ratingContext);
            return result;
        }

        [Authorize]
        [HttpGet("GetUserRating")]
        public MoviesRating GetUserRating(int MovieId)
        {
            var result = _movies.GetRating(MovieId);
            return result;
        }
    }
}
