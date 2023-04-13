namespace OpinionAPI.Context
{
    public class AddMoviesContext
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public IFormFile Image { get; set; }
    }
}
