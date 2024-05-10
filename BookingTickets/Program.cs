using BookingTickets.Business.Extensions;
using BookingTickets.DataLayer;
using BookingTickets.Extensions;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Logging.ClearProviders();

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateBootstrapLogger();

    // Add services to the container.

    builder.Services.ConfigureApiServices(builder.Configuration);
    builder.Services.ConfigureBllServices();
    builder.Services.ConfigureDalServices();

    builder.Services.AddMappers();

    builder.Host.UseSerilog();

    var app = builder.Build();
    app.UseApplication();
    app.MapControllers();

    Log.Information("Running app");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex.Message);
}
finally
{
    Log.CloseAndFlush();
}