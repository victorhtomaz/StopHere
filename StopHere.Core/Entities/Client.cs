using StopHere.Core.ValueObjects;

namespace StopHere.Core.Entities;

public class Client : BaseEntity
{
    public Client(string nome, Phone phone, ClientService service, Vehicle vehicle, ParkingPlace parkingPlace)
    {
        Nome = nome;
        Phone = phone;
        Service = service;
        Vehicle = vehicle;
        ParkingPlace = parkingPlace;
    }

    public string Nome {  get; set; }
    public Phone Phone { get; set; }
    public ClientService Service { get; set; }
    public Vehicle Vehicle { get; set; }
    public ParkingPlace ParkingPlace { get; set; } 
}
