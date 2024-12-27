using System.ComponentModel.DataAnnotations;

namespace StopHere.Core.Dtos.Requests.VehicleRequests;

public class GetVehicleRequest : Request
{
    [Required]
    [StringLength(7, MinimumLength = 7, ErrorMessage ="É necessário 7 caracteres")]
    public string LicensePlateValue { get; set; } = string.Empty;
}
