using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LoggingAPI.Filters;

/// <summary>
/// Filter handling unhandled exceptions.
/// </summary>
public class ExceptionFilter : IExceptionFilter
{
    private readonly IHostEnvironment _hostEnvironment;

    public ExceptionFilter(IHostEnvironment hostEnvironment) =>
        _hostEnvironment = hostEnvironment;

    public void OnException(ExceptionContext context)
    {
        if (!_hostEnvironment.IsDevelopment())
        {
            context.Result = new ContentResult
            {
                Content = "Something went wrong. Please contact the development team.",
                StatusCode = StatusCodes.Status500InternalServerError
            };
            return;
        }

        context.Result = new ContentResult
        {
            Content = context.Exception.ToString(),
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }
}
