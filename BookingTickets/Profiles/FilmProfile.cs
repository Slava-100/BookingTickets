using AutoMapper;
using BookingTickets.Core.Models.API.Request;
using BookingTickets.Core.Models.API.Response;
using BookingTickets.Core.Models.BLL;
using BookingTickets.Core.Models.Dto;

namespace BookingTickets.Profiles;

public class FilmProfile : Profile
{
    public FilmProfile()
    {
        CreateMap<FilmDto, Film>().ReverseMap();
        CreateMap<Film, FilmResponse>();
        CreateMap<FilmRequest, Film>();
    }
}
