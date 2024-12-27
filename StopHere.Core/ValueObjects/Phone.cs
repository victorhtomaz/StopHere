using System.Text.RegularExpressions;

namespace StopHere.Core.ValueObjects;

public class Phone
{
    public Phone(string number)
    {
        Number = ChangeFormat(number);
    }
    public string Number { get; set; }

    private string ChangeFormat(string number)
    {
        return Regex.Replace(number, @"\D", "");
    }

    public bool Validate()
    {
        if (Number.Length != 11)
            return false;

        return true;
    }
}
