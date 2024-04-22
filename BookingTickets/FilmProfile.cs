using AutoMapper;
using BookingTickets.Core.Models.API;
using BookingTickets.Core.Models.BLL;
using BookingTickets.Core.Models.Dtos;

namespace BookingTickets;

public class FilmProfile : Profile
{
    public FilmProfile()
    {
        //CreateMap<FilmDto, Film>();
        CreateMap<Film, FilmResponse>();
    }
}
