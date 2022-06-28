namespace LoggingAPI.Abstractions;

/// <summary>
/// Interface for database operations.
/// </summary>
public interface ILogMessageDbRepository
{
    /// <summary>
    /// Adds a bulk of new log messages to the database.
    /// </summary>
    /// <remarks>
    /// If log messages are created by new applications, also adds the application to the database.
    /// Otherwise refereence to an exiting application record is used.
    /// </remarks>
    /// <param name="logMessages">Bulk of new log messages.</param>
    /// <returns>Asynchronous task to be awaited.</returns>
    public Task AddLogMessagesAsync(ICollection<Models.LogMessage> logMessages);
}