namespace LoggingAPI.Interfaces;

internal interface ILogMessageParser
{
    /// <summary>
    /// Extracts <see cref="Models.LogLevel"/> from <paramref name="logMessage"/>.
    /// </summary>
    /// <param name="logMessage">Actual message received sent by API clients.</param>
    /// <returns>Extracted log level and remaining message.</returns>
    public (Models.LogLevel LogLevel, string Text) Parse(string logMessage);
}
