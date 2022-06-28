using LoggingAPI.Abstractions;
using LoggingAPI.PostgresDb.Models;
using Microsoft.Extensions.Logging;

namespace LoggingAPI.PostgresDb.Repositories;

public class LogMessageDbRepository : ILogMessageDbRepository
{
    private readonly ILogger<LogMessageDbRepository> logger;
    private readonly LoggingContext context;

    public LogMessageDbRepository(ILogger<LogMessageDbRepository> logger, LoggingContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    public async Task AddLogMessagesAsync(ICollection<LoggingAPI.Models.LogMessage> logMessages)
    {
        logger.LogDebug("Adding {LogMessagesCount} log messages to the database...", logMessages.Count);

        ScheduleChanges(logMessages);

        await context.SaveChangesAsync();

        logger.LogDebug("Adding log messages to the database finished succesfully.");
    }

    private void ScheduleChanges(ICollection<LoggingAPI.Models.LogMessage> logMessages)
    {
        var appGroups = logMessages
            .Where(m => !string.IsNullOrEmpty(m.ApplicationName))
            .GroupBy(m => m.ApplicationName!);

        var appNames = appGroups
            .Select(g => g.Key!)
            .ToArray();

        var appsDict = context.Applications
            .Where(a => appNames.Contains(a.Name))
            .ToDictionary(a => a.Name!, a => a.Id);

        var logMessagesToBeAdded = new List<LogMessage>(logMessages.Count);
        var appsToBeAdded = new List<Application>(appNames.Length);

        foreach (var group in appGroups)
        {
            var appExists = appsDict.TryGetValue(group.Key, out int existingAppId);
            var appLogMessages = group.Select(m => new LogMessage
            {
                Message = m.Message,
                Date = m.Date,
                LogLevel = m.LogLevel,
                ApplicationId = existingAppId
            }).ToList();

            if (appExists)
            {
                logMessagesToBeAdded.AddRange(appLogMessages);
            }
            else
            {
                appsToBeAdded.Add(new Application
                {
                    Name = group.Key,
                    LogMessages = appLogMessages
                });
            }
        }

        context.LogMessages.AddRange(logMessagesToBeAdded);
        context.Applications.AddRange(appsToBeAdded);
    }
}
