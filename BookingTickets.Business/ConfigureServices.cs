

using BookingTickets.Core.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace BookingTickets.Business;

public static class ConfigureServices
{
    public static void ConfigureBllServices(this IServiceCollection services)
    {
        services.AddScoped<IFilmManager, FilmManager>();
    }
}
