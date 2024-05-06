using AutoMapper;
using BookingTickets.Core.Contracts;
using BookingTickets.Core.Models.API.Response;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BookingTickets.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionsController(ISessionManager sessionManager, IMapper mapper) : Controller
{
    private readonly Serilog.ILogger _logger = Log.ForContext<SessionsController>();

    [HttpGet("/sessions/film/{id}")]
    public async Task<ActionResult<List<SessionResponse>>> GetSessionsByFilmIdAsync([FromRoute] Guid id, [FromQuery] DateTime? dateTime)
    {
        _logger.Information("Получаем все сеансы по id {id} фильма", id);
        var callback = await sessionManager.GetSessionsByFilmIdAsync(id, dateTime);
        var session = mapper.Map<List<SessionResponse>>(callback);

        return Ok(session);
    }
}

