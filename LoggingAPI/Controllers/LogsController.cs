using LoggingAPI.Contracts;
using LoggingAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoggingAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class LogsController : ControllerBase
{
    private readonly ILogsHandler handler;

    public LogsController(ILogsHandler handler)
    {
        this.handler = handler;
    }

    /// <summary>
    /// Method handling POST /logs requests - saves bulk of new log messages.
    /// </summary>
    /// <param name="logMessageModels">Bulk of new log messages.</param>
    /// <returns>Asynchronous task to be awaited with HTTP response.</returns>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] IEnumerable<LogMessage> logMessageModels)
    {
        await handler.HandleAsync(logMessageModels);

        return Ok("Logs saved.");
    }
}
