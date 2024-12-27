using System.ComponentModel.DataAnnotations;

namespace StopHere.Core.Dtos.Requests.ClientRequests;

public class GetClientByPhoneNumberRequest : Request
{
    [Required]
    [MaxLength(30, ErrorMessage = "Máximo de 30 caracteres")]
    public string PhoneNumber { get; set; } = string.Empty;
}