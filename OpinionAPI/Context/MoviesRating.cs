using OpinionAPI.Model;

namespace OpinionAPI.Context
{
    public class MoviesRating
    {
        public string? MovieName { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? TotalRating { get; set; }

        public List<UserRate>? ratings { get; set; }
    }

    public class UserRate
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? MovieName { get; set; }
        public int MovieRating { get; set; }
        public string? Comment { get; set; }

    }
}
