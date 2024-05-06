using AutoMapper;
using BookingTickets.Core.Contracts;
using BookingTickets.Core.Models.API.Request;
using BookingTickets.Core.Models.API.Response;
using BookingTickets.Core.Models.BLL;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BookingTickets.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmsController(IFilmManager filmManager, IMapper mapper) : Controller
{
    private readonly Serilog.ILogger _logger = Log.ForContext<FilmsController>();

    [HttpGet("/films")]
    public async Task<ActionResult<IEnumerable<FilmResponse>>> GetFilmsAsync()  
    {
        _logger.Information("Получаем все фильмы");
        var callback = await filmManager.GetFilmsAsync();
        var films = mapper.Map<IEnumerable<FilmResponse>>(callback);

        return Ok(films);
    }

    [HttpGet("/film/{id}")]
    public async Task<ActionResult<FilmResponse>> GetFilmByIdAsync([FromRoute] Guid id) 
    {
        _logger.Information("Получаем фильм по {id}", id);
        var callback = await filmManager.GetFilmByIdAsync(id);
        var film = mapper.Map<FilmResponse>(callback);

        return Ok(film);
    }

    [HttpPost()]
    public async Task<ActionResult<Guid>> AddFilmAsync([FromBody] FilmRequest filmRequest)
    {
        _logger.Information("Добавляем фильм");
        var filmId = await filmManager.AddFilmAsync(mapper.Map<Film>(filmRequest));
        return filmId;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateFilmAsync([FromRoute] Guid id,
        [FromQuery] FilmRequest filmRequest)
    {
        _logger.Information("Обновляем фильм с id {id}", id);
        var film = mapper.Map<Film>(filmRequest);
        film.Id = id;
        await filmManager.UpdateFilmAsync(film);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteFilmAsync([FromRoute] Guid id)
    {
        _logger.Information("Удаляем фильм с id {id}", id);
        await filmManager.DeleteFilmAsync(id);
        return Ok();
    }
}
