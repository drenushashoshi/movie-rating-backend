using Xunit;
using Moq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using movie_rating_backend.Entity;
using movie_rating_backend.Models.DTOs.MovieDtos;
using movie_rating_backend.Services.Implementations;
using movie_rating_backend.Mappings;
using Moq.EntityFrameworkCore;

namespace movie_rating_backend.test
{
    public class MovieServiceTests
    { 
       /* private Mock<AppDbContext> _mockDbContext = new();


        

        [Theory]
        [InlineData("Movie 3")]
        [InlineData("Movie 4")]
        [InlineData("Joker")]
        public void GetMoviesByTitle_Should_Be_Null(string movieTitle)
        {

            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MovieMapperProfile()));
            var mapper = config.CreateMapper();
            var mockedMovies = GetMovies();
            _mockDbContext.Setup(m => m.Movies).ReturnsDbSet(mockedMovies);
            var movieService = new MovieService(_mockDbContext.Object, mapper);



            
            var getMovie = movieService.GetMovieByTitle(movieTitle).Result;

            
            Assert.Null(getMovie);

        }

        //[Fact]
        /*public void GetMovieByTitle_Finds_Movies_ByTitle()
        {
            
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MovieMapperProfile()));
            var mapper = config.CreateMapper();
            var mockedMovies = GetMovies();
            _mockDbContext.Setup(m => m.Movies).ReturnsDbSet(mockedMovies);
            var movieService = new MovieService(_mockDbContext.Object, mapper);



            
            var movieTitle = movieService.GetMovieByTitle("Movie 2").Result;

            
            Assert.NotNull(movieTitle);
            Assert.Equal("Movie 2", movieTitle.Title);
        }
        
       

        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "Movie 1",
                    Description = "Description 1",
                    Year = 2020,
                    CoverImageUrl = "url1"
                },
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "Movie 2",
                    Description = "Description 2",
                    Year = 2021,
                    CoverImageUrl = "url2"
                }
            };
        }*/

        
      
    }
}
