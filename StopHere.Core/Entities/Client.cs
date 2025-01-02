using StopHere.Core.ValueObjects;

namespace StopHere.Core.Entities;

public class Client : BaseEntity
{
    public Client(string name, Phone phone, ClientService service, Vehicle vehicle, ParkingPlace parkingPlace)
    {
        Name = name;
        Phone = phone;
        Service = service;
        Vehicle = vehicle;
        ParkingPlace = parkingPlace;
    }

    public string Name {  get; set; }
    public Phone Phone { get; set; }
    public ClientService Service { get; set; }
    public Vehicle Vehicle { get; set; }
    public ParkingPlace ParkingPlace { get; set; }
}
