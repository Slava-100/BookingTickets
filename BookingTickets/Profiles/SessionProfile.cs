using AutoMapper;
using BookingTickets.Core.Models.API.Response;
using BookingTickets.Core.Models.BLL;
using BookingTickets.Core.Models.DTO;

namespace BookingTickets.Profiles;

public class SessionProfile : Profile
{
    public SessionProfile()
    {
        CreateMap<SessionDto, Session>();
        CreateMap<Session, SessionResponse>();
    }
}