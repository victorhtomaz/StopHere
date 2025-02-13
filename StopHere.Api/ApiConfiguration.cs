namespace StopHere.Api;

public static class ApiConfiguration
{
    public const string CorsPolicyName = "wasm";
    public static string ConnectionString {  get; set; } = string.Empty;
    public static Dictionary<string, string> Roles { get; set; } = new();
}
