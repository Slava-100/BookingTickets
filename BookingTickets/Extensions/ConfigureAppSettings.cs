using BookingTickets.Business;

namespace BookingTickets.Extensions;

public static class ConfigureAppSettings
{
    public static void AddConfigurationFromAppSettings(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped(s => configuration.GetSection("Secrets").Get<Secrets>(options => options.BindNonPublicProperties = true));
    }
}

