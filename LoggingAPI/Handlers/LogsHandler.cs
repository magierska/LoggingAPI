using LoggingAPI.Abstractions;
using LoggingAPI.Contracts;
using LoggingAPI.Interfaces;

namespace LoggingAPI.Handlers;

internal class LogsHandler : ILogsHandler
{
    private readonly ILogMessageMapper mapper;
    private readonly ILogMessageDbRepository dbRepository;

    public LogsHandler(ILogMessageMapper mapper, ILogMessageDbRepository dbRepository)
    {
        this.mapper = mapper;
        this.dbRepository = dbRepository;
    }

    public Task HandleAsync(IEnumerable<LogMessage> logMessages)
    {
        var logMessagesConverted = logMessages.Select(mapper.Map).ToList();
        return dbRepository.AddLogMessagesAsync(logMessagesConverted);
    }
}
