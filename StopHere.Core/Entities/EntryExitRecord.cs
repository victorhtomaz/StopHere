﻿namespace StopHere.Core.Entities;

public class EntryExitRecord : BaseEntity
{
    public EntryExitRecord(string licensePlateValue, Guid parkingSpaceId)
    {
        EntryDate = DateTime.Now;
        LicensePlateValue = licensePlateValue;
        ParkingSpaceId = parkingSpaceId;
    }

    public DateTime EntryDate { get; set; }
    public DateTime? ExitDate { get; set; }
    public TimeSpan? Duration { get; set; }
    public string LicensePlateValue { get; set; }
    public Guid ParkingSpaceId {  get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public void ChangeExitDate()
    {
        ExitDate = DateTime.Now;
        Duration = ExitDate.Value.Subtract(EntryDate);
    }
}
