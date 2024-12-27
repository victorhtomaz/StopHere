using StopHere.Core.Enums;

namespace StopHere.Core.ValueObjects;

public class ClientService
{
    public ClientService(EServiceTypes type)
    {
        Type = type;
        ExpiryDate = GetExpiryDate();
    }
    public EServiceTypes Type { get; set; }
    public DateTime ExpiryDate { get; set; }

    public DateTime GetExpiryDate()
    {
        if (Type == EServiceTypes.Weekly)
            return DateTime.Now.AddDays(7);

        return DateTime.Now.AddMonths(1);
    }
}
