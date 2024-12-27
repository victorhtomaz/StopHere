using StopHere.Core.Dtos.Requests.ParkingPlaceRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;

namespace StopHere.Core.Handlers;

public interface IParkingPlaceHandler
{
    Task<Response<ParkingPlace?>> Create(CreateParkingPlaceRequest request);
    Task<Response<ParkingPlace?>> Delete(DeleteParkingPlaceRequest request);
    Task<Response<ParkingPlace?>> Get(GetParkingPlaceRequest request);
}
