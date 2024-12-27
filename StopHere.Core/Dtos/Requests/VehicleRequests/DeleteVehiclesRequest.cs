using System.ComponentModel.DataAnnotations;

namespace StopHere.Core.Dtos.Requests.VehicleRequests;

public class DeleteVehiclesRequest : Request
{
    public IList<string> LicensePlateValues { get; set; } = new List<string>();
}
