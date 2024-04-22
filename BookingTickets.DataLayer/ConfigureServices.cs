

using BookingTickets.Core.Contracts;
using BookingTickets.Core.Models.Dtos;
using BookingTickets.DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookingTickets.DataLayer;

public static class ConfigureServices
{
    public static void ConfigureDalServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
    }
}

