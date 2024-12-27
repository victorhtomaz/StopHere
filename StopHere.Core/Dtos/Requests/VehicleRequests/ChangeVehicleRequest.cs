using System.ComponentModel.DataAnnotations;

namespace StopHere.Core.Dtos.Requests.VehicleRequests;

public class ChangeVehicleRequest : Request
{
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "É necessário 3 à 50 caracteres")]
    public string Color { get; set; } = string.Empty;

    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "É necessário 2 à 50 caracteres")]
    public string Model { get; set; } = string.Empty;

    [Required]
    [StringLength(7, MinimumLength = 7, ErrorMessage = "É necessário 7 caracteres")]
    public string LicensePlateValue { get; set; } = string.Empty;
}
