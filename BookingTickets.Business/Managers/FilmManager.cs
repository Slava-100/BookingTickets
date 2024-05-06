using AutoMapper;
using BookingTickets.Core.Contracts;
using BookingTickets.Core.Exceptions;
using BookingTickets.Core.Models.BLL;
using BookingTickets.Core.Models.Dto;
using Serilog;

namespace BookingTickets.Business.Managers;

public class FilmManager(IRepository<FilmDto> baseRepository, IMapper mapper) : IFilmManager
{
    private readonly Serilog.ILogger _logger = Log.ForContext<FilmManager>();
    public async Task<IEnumerable<Film>> GetFilmsAsync()
    {
        _logger.Information("Обращаемся к методу репозитория получение всех фильмов");
        var callback = await baseRepository.GetAllAsync();
        var films = mapper.Map<IEnumerable<Film>>(callback);

        return films;
    }

    public async Task<Guid> AddFilmAsync(Film film)
    {
        _logger.Information("Обращаемся к методу репозитория добавления фильма");
        var filmCallback = await baseRepository.AddAsync(mapper.Map<FilmDto>(film));
        return filmCallback.Id;
    }
    public async Task UpdateFilmAsync(Film film)
    {
        _logger.Information("Проверяем существует ли фильм с id {id}", film.Id);

        var callback = await baseRepository.GetByIdAsync(film.Id);
        if (callback is null)
            throw new EntityNotFoundException($"Фильма с id {film.Id} не существует");

        _logger.Information("Обращаемся к методу репозитория обновления фильма");
        await baseRepository.UpdateAsync(mapper.Map<FilmDto>(film));
    }
    public async Task DeleteFilmAsync(Guid id)
    {
        _logger.Information("Проверяем существует ли фильм с id {id}", id);

        var callback = await baseRepository.GetByIdAsync(id);
        if (callback is null)
            throw new EntityNotFoundException($"Фильма с id {id} не существует");

        _logger.Information("Обращаемся к методу репозитория удаления фильма");
        await baseRepository.DeleteAsync(callback);
    }

    public async Task<Film> GetFilmByIdAsync(Guid id)
    {
        _logger.Information("Обращаемся к методу репозитория получения фильма по id {id}", id);
        var callback = await baseRepository.GetByIdAsync(id);

        if (callback is null)
            throw new EntityNotFoundException($"Фильма с id {id} не существует");

        var film = mapper.Map<Film>(callback);

        return film;
    }
}

