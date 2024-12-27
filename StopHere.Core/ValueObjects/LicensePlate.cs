using System.Text.RegularExpressions;

namespace StopHere.Core.ValueObjects;

public class LicensePlate
{
    public LicensePlate(string value)
    {
        Value = value;
    }
    public string Value { get; set; }
    
    public bool Validate()
    {
        return Regex.IsMatch(Value, @"[A-Z]{3}[0-9][0-9A-Z][0-9]{2}");
    }
}
