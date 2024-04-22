using AutoMapper;
using BookingTickets.Core.Contracts;
using BookingTickets.Core.Models.BLL;
using BookingTickets.Core.Models.Dtos;

namespace BookingTickets.Business;

public class FilmManager(IRepository<FilmDto> filmRepository, IMapper mapper) : IFilmManager
{
    public async Task<IEnumerable<Film>> GetFilmsAsync()
    {
        var callback = await filmRepository.GetAllAsync();
        var films = mapper.Map<IEnumerable<Film>>(callback);

        return films;
    }
}
