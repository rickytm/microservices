using Microsoft.Extensions.Logging.Console;

namespace Localization.API.Extensions.CustomFormatters;
public sealed class CustomWrappingConsoleFormatterOptions : ConsoleFormatterOptions
{
    public string? CustomPrefix { get; set; }

    public string? CustomSuffix { get; set; }
}
