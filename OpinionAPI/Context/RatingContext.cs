namespace OpinionAPI.Context
{
    public class RatingContext
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int MovieRating { get; set; }
        public string? Comment { get; set; }
    }
}
