using AutoMapper;
using movie_rating_backend.Entity;
using movie_rating_backend.Models.DTOs.UserDtos;

namespace movie_rating_backend.Mappings
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, GetUserDto>();
            CreateMap<User, UserLoginDto>();
        }
    }
}
