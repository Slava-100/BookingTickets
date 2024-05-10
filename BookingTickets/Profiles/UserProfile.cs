using AutoMapper;
using BookingTickets.Core.Models.API.Request;
using BookingTickets.Core.Models.API.Response;
using BookingTickets.Core.Models.BLL;
using BookingTickets.Core.Models.DTO;

namespace BookingTickets.Profiles;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserResponse>();
    }
}