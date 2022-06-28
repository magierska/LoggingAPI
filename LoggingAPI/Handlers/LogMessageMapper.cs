using LoggingAPI.Interfaces;
using LoggingAPI.Models;

namespace LoggingAPI.Handlers;

internal class LogMessageMapper : ILogMessageMapper
{
    private readonly ILogMessageParser parser;

    public LogMessageMapper(ILogMessageParser parser)
    {
        this.parser = parser;
    }

    public LogMessage Map(Contracts.LogMessage message)
    {
        var (logLevel, text) = parser.Parse(message.Message!);
        return new LogMessage
        {
            Date = message.LogDate.HasValue ? DateTimeOffset.FromUnixTimeSeconds(message.LogDate!.Value) : Defaults.LogDate,
            ApplicationName = message.Application,
            Message = text,
            LogLevel = logLevel
        };
    }
}
