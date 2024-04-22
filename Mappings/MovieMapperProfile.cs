using AutoMapper;
using movie_rating_backend.Entity;

using movie_rating_backend.Models.DTOs.MovieDtos;
using movie_rating_backend.Models.DTOs.RatingDtos;

namespace movie_rating_backend.Mappings
{
    public class MovieMapperProfile: Profile
    {
        public MovieMapperProfile() {
            CreateMap<Movie, CreateMovieDto>();
            CreateMap<Movie, GetMovieDto>();
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<GetMovieDto, Movie>();

            CreateMap<Rating, CreateRatingDto>();
            CreateMap<CreateRatingDto, Rating>();
        }
    }
}
