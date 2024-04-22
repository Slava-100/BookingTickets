using AutoMapper;
using BookingTickets.Core.Contracts;
using BookingTickets.Core.Models.API;
using Microsoft.AspNetCore.Mvc;
using BookingTickets.Core.Models.Dtos;

namespace BookingTickets.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmController(IFilmManager filmManager, IMapper mapper) : Controller
{
    [HttpGet("/films")]
    public async Task<ActionResult<IEnumerable<FilmResponse>>> GetFilmsAsync() //пока без маппинга, поэтому FilmDto 
    {
        var callback = await filmManager.GetFilmsAsync();
        var films = mapper.Map<IEnumerable<FilmResponse>>(callback);

        return Ok(films);
    }

}
