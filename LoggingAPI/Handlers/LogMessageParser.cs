using LoggingAPI.Interfaces;
using LoggingAPI.Models;
using System.Text.RegularExpressions;

namespace LoggingAPI.Handlers;

internal class LogMessageParser : ILogMessageParser
{
    public (Models.LogLevel LogLevel, string Text) Parse(string logMessage)
    {
        var regex = new Regex(@"^\s*\[\s*(?<logLevel>\w*)\s*\]", RegexOptions.Compiled);
        var match = regex.Match(logMessage);
        if (match.Success && Enum.TryParse(match.Groups["logLevel"].Value, ignoreCase: true, out Models.LogLevel logLevelEnum))
        {
            var text = logMessage[match.Length..].Trim();
            return (logLevelEnum, text);
        }

        return (Defaults.LogLevel, logMessage.Trim());
    }
}
