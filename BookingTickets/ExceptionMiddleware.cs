using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Text.Json;

namespace BookingTickets;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            await HandlerExceptionAsync(context, ex);
        }
    }

    private static Task HandlerExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        string result = JsonSerializer.Serialize(ex);
        return context.Response.WriteAsync(result);
    }
}