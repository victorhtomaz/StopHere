namespace StopHere.Core.Entities;

public class ParkingPlace : BaseEntity
{
    public ParkingPlace()
    {
        IsOccupied = false;
    }
    public int Number { get; set; }
    public bool IsOccupied { get; set; }
    public Guid? ClientId { get; set; }
}
