using BookingTickets.Business.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace BookingTickets.Business.Extensions;
public static class ConfigureValidators
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddSingleton<UserValidator>();
    }
}