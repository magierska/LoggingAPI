namespace LoggingAPI.Interfaces;

internal interface ILogMessageMapper
{
    /// <summary>
    /// Maps <see cref="Contracts.LogMessage"/> into <see cref="Models.LogMessage"/> with business case specific parsing.
    /// </summary>
    /// <param name="message">Message in format provided by API clients.</param>
    /// <returns>Message in business object format.</returns>
    Models.LogMessage Map(Contracts.LogMessage message);
}
