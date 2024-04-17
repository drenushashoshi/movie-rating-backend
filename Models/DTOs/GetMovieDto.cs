namespace movie_rating_backend.Models.DTOs
{
    public class GetMovieDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
