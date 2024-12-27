using StopHere.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace StopHere.Core.Dtos.Requests.ClientRequests;

public class RenewServiceClientRequest : Request
{
    [Required]
    [Range(1, 2, ErrorMessage = "O valor precisa ser entre 1 e 2")]
    public EServiceTypes ServiceType { get; set; }

    [Required(ErrorMessage = "O número da vaga é necessário")]
    public int ParkingPlaceNumber { get; set; }
}
