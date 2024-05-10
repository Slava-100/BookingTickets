using BookingTickets.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Extensions;

public static class DataBaseExtensions
{
    public static void ConfigureDataBase(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddDbContext<Context>(
            options => options
                            .UseNpgsql(configurationManager.GetConnectionString("Connection"))
                            .UseSnakeCaseNamingConvention()
            );
    }
}
