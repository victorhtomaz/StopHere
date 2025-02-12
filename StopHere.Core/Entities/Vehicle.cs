﻿using StopHere.Core.ValueObjects;

namespace StopHere.Core.Entities;

public class Vehicle : BaseEntity
{
    protected Vehicle() { }
    public Vehicle(string color, string model, LicensePlate licensePlate)
    {
        Color = color;
        Model = model;
        LicensePlate = licensePlate;
        EntryExitRecords = new List<EntryExitRecord>();
    }
    public string Color { get; set; }
    public string Model { get; set; }
    public LicensePlate LicensePlate { get; set; }
    public IList<EntryExitRecord> EntryExitRecords { get; set; }
    public Guid? ClientId { get; set; }
    public Client? Client { get; set; }

    public void ChangeInformation(string color, string model)
    {
        Color = color;
        Model = model;
    }
}
