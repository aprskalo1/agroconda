using System.Net;
using AgrocondaAPI.Exceptions;
using AgrocondaAPI.Models.Common;

namespace AgrocondaAPI.Middleware;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (AgrocondaCustomException ex)
        {
            await HandleCustomExceptionAsync(context, ex);
        }
        catch (Exception)
        {
            await HandleGeneralExceptionAsync(context);
        }
    }

    private static Task HandleCustomExceptionAsync(HttpContext context, AgrocondaCustomException exception)
    {
        var statusCode = exception switch
        {
            ParcelNotFoundException => HttpStatusCode.NotFound,
            TokenNotFoundException => HttpStatusCode.NotFound,
            UserNotFoundException => HttpStatusCode.NotFound,
            UnauthorizedException => HttpStatusCode.Unauthorized,
            _ => HttpStatusCode.BadRequest
        };

        var errorResponse = new ErrorResponse
        {
            Message = exception.Message,
            StatusCode = ((int)statusCode).ToString(),
            TimeStamp = DateTime.Now
        };

        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsJsonAsync(errorResponse);
    }

    private static Task HandleGeneralExceptionAsync(HttpContext context)
    {
        var errorResponse = new ErrorResponse
        {
            Message = "An unexpected error occurred.",
            StatusCode = "500",
            TimeStamp = DateTime.Now
        };

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsJsonAsync(errorResponse);
    }
}