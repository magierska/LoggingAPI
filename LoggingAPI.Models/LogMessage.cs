namespace LoggingAPI.Models;

/// <summary>
/// Log messages in business object format.
/// </summary>
public class LogMessage
{
    /// <summary>
    /// Date and time of the message creation with timezone specified.
    /// </summary>
    /// <remarks>Defaults to current UTC date and time.</remarks>
    public DateTimeOffset? Date { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// The text of the message.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// The name of the application that’s logging the message.
    /// </summary>
    public string? ApplicationName { get; set; }

    /// <summary>
    /// Log level of the message.
    /// </summary>
    /// <remarks>Defaults to <see cref="LogLevel.Info"/>.</remarks>
    public LogLevel LogLevel { get; set; } = LogLevel.Info;
}