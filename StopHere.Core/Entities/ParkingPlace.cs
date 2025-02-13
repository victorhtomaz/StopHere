namespace StopHere.Core.Entities;

public class ParkingPlace : BaseEntity
{
    protected ParkingPlace() { }    
    public ParkingPlace(int number)
    {
        Number = number;
        IsOccupied = false;
    }
    public int Number { get; set; }
    public bool IsOccupied { get; set; }
    public Guid? ClientId { get; set; }
    public Client? Client { get; set; }
}
