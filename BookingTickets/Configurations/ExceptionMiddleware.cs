using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Text.Json;
using BookingTickets.Core.Exceptions;

namespace BookingTickets.Configurations;

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
        string message = ex.Message;
        int code = ex switch
        {
            BadRequestException => 400,
            NotAuthorizedException => 401,
            EntityNotFoundException => 404,
            NotAllowToEditEntityException => 406,
            InvalidEmailFormatException
                or EmailAlreadyExistsException => 422,
            NpgsqlException
                or DbUpdateException => 500,
            _=> 400
        };
        ExceptionDetails exR = new(message, code);
        string result = JsonSerializer.Serialize(exR);
        context.Response.StatusCode = exR.Code;
        return context.Response.WriteAsync(result);
    }
}