
using BookingTickets.Configurations;
using Serilog;

namespace BookingTickets.Extensions;

public static class ConfigureUseApplication
{
    public static void UseApplication(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseSerilogRequestLogging();

        app.UseAuthentication();
        app.UseAuthorization();

    }
}

