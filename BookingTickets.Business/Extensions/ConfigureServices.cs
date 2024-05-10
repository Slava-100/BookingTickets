using BookingTickets.Business.Extensions;
using BookingTickets.Business.Services;
using BookingTickets.Core.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace BookingTickets.Business.Extensions;

public static class ConfigureServices
{
    public static void ConfigureBllServices(this IServiceCollection services)
    {
        services.AddScoped<IFilmService, FilmService>();
        services.AddScoped<ISessionService, SessionService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddValidators();
    }
}
