using AutoMapper;
using Microsoft.EntityFrameworkCore;
using movie_rating_backend.Entity;
using movie_rating_backend.Models.DTOs;

namespace movie_rating_backend.Services
{
    public class MovieService: IMovieService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public MovieService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;

        }

        public async Task<GetMovieDto> CreateMovie(CreateMovieDto newMovieDto)
        {


            var newMovie = _mapper.Map<Movie>(newMovieDto);


            _appDbContext.Movies.Add(newMovie);
            await _appDbContext.SaveChangesAsync();


            return _mapper.Map<GetMovieDto>(newMovie);
        }

        public async Task<List<GetMovieDto>> GetAllMovies()
        {

            var moviesDto = _mapper.ProjectTo<GetMovieDto>(_appDbContext.Movies);

            return moviesDto.ToList();



        }

        public async Task<GetMovieDto> GetMovieByTitle(string title)
        {
            var movie = await _appDbContext.Movies.FirstOrDefaultAsync(m => m.Title == title);
            if (movie == null)
            {
                return null;
            }
            return _mapper.Map<GetMovieDto>(movie);



        }

    }
}
