using StopHere.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace StopHere.Core.Dtos.Requests.ClientRequests;

public class CreateClientRequest : Request
{
    [Required]
    [StringLength(125, MinimumLength = 2, ErrorMessage = "É necessário 2 à 125 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [MaxLength(30, ErrorMessage = "Máximo de 30 caracteres")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [Range(1,2, ErrorMessage = "O valor precisa ser entre 1 e 2")]
    public EServiceTypes ServiceType { get; set; }

    [Required]
    [StringLength(7, MinimumLength = 7, ErrorMessage = "É necessário 7 caracteres"]
    public string LicensePlateValue { get; set; } = string.Empty;

    [Required(ErrorMessage = "O número da vaga é necessário")]
    public int ParkingPlaceNumber { get; set; }
}
