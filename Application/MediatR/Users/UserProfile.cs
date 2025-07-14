using Application.MediatR.Users.CreateUser;
using AutoMapper;
using Domain.Entities;

namespace Application.MediatR.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserCommand, User>();
        }
    }
}
