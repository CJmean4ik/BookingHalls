using Api.Contracts;
using Domain.Shared;
using Serilog;

namespace Api.Middlewares;

public class ExceptionsHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IResponceFactory _responceFactory;

    public ExceptionsHandlerMiddleware(RequestDelegate next, IResponceFactory responceFactory)
    {
        _next = next;
        _responceFactory = responceFactory;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            Log.Error("An error has occurred: {0}",ex.StackTrace);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var errorResponce = _responceFactory.CreateErrorResponce(ex: ex);
            await context.Response.WriteAsJsonAsync(errorResponce);
            
        }
    }
}