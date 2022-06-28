using System.ComponentModel.DataAnnotations;

namespace LoggingAPI.Contracts;

/// <summary>
/// Log message in format agreed with API's clients.
/// </summary>
public class LogMessage
{
    /// <summary>
    /// Unix epoch timestamp of the log message creation in UTC timezone.
    /// </summary>
    /// <remarks>Defaults to current UTC date and time.</remarks>
    /// <example>1600935069</example>
    public long? LogDate { get; set; }

    /// <summary>
    /// The actual content of the log message.
    /// </summary>
    /// <remarks>May start with the <see cref="Models.LogLevel"/> indication in square brackets. Level defaults to <see cref="Models.LogLevel.Info"/> if not specified.</remarks>
    /// <example>[error] Could not connect to the database!</example>
    [Required]
    public string? Message { get; set; }

    /// <summary>
    /// The name of the application that’s logging the message.
    /// </summary>
    /// <example>px_demo_app</example>
    [Required]
    public string? Application { get; set; }
}