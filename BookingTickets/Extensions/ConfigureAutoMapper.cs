using BookingTickets.Profiles;

namespace BookingTickets.Extensions;
public static class ConfigureAutoMapper
{
    public static void AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(FilmProfile));
        services.AddAutoMapper(typeof(SessionProfile));
        services.AddAutoMapper(typeof(HallProfile)); 
        services.AddAutoMapper(typeof(UserProfile));
    }
}