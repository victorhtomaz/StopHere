using System.ComponentModel.DataAnnotations;

namespace StopHere.Core.Dtos.Requests.ParkingPlaceRequests;

public class GetParkingPlaceRequest : Request
{
    [Required(ErrorMessage = "É necessário o número da vaga")]
    public int Number {  get; set; }
}
