using Microsoft.AspNetCore.Mvc;
using OpinionAPI.Context;
using OpinionAPI.Model;

namespace OpinionAPI.Interface
{
    public interface IMovies
    {
        Task<ActionResult> AddMovie(AddMoviesContext movies);
        List<Movies> GetMovies();
        Task<ActionResult> AddRating(RatingContext ratingContext);
        MoviesRating GetRating(int movieid);
    }
}
