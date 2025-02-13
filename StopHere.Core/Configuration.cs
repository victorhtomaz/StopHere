namespace StopHere.Core;

public class Configuration
{
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 20;

    public static string BackendUrl { get; set; } = string.Empty;
    public static string FrontendUrl {  get; set; } = string.Empty;

}
