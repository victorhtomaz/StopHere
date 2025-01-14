using StopHere.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace StopHere.Core.Dtos.Requests.ClientRequests;

public class ChangeClientRequest : Request
{
    public Guid ClientId { get; set; }

    [Required]
    [StringLength(125, MinimumLength = 2, ErrorMessage = "É necessário 2 à 125 caracteres")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(30, ErrorMessage = "Máximo de 30 caracteres")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(7, MinimumLength = 7, ErrorMessage = "É necessário 7 caracteres")]
    public string LicensePlateValue { get; set; } = string.Empty;
}
