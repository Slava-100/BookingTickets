using BookingTickets.Business.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace BookingTickets.Business.Extensions;
public static class ConfigureValidations
{
    public static void AddValidations(this IServiceCollection services)
    {
        services.AddSingleton<UserValidator>();
    }
}