using LoggingAPI.Contracts;

namespace LoggingAPI.Interfaces;

public interface ILogsHandler
{
    Task HandleAsync(IEnumerable<LogMessage> logMessages);
}
