using AutoMapper;
using BookingTickets.Core.Models.API.Response;
using BookingTickets.Core.Models.BLL;
using BookingTickets.Core.Models.DTO;


namespace BookingTickets.Profiles;

public class HallProfile : Profile
{
    public HallProfile()
    {
        CreateMap<HallDto, Hall>();
        CreateMap<Hall, HallResponse>();
    }
}
