using BookingTickets.Business.Extensions;
using BookingTickets.Business.Managers;
using BookingTickets.Core.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace BookingTickets.Business.Extensions;

public static class ConfigureServices
{
    public static void ConfigureBllServices(this IServiceCollection services)
    {
        services.AddScoped<IFilmManager, FilmManager>();
        services.AddScoped<ISessionManager, SessionManager>();
        services.AddScoped<IUserManager, UserManager>();
        services.AddScoped<ITokenManager, TokenManager>();

        services.AddValidations();
    }
}
