using StopHere.Core.Dtos.Requests.ParkingPlaceRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;

namespace StopHere.Core.Handlers;

public interface IParkingPlaceHandler
{
    Task<Response<ParkingPlace?>> CreateAsync(CreateParkingPlaceRequest request);
    Task<Response<ParkingPlace?>> DeleteAsync(DeleteParkingPlaceRequest request);
    Task<Response<ParkingPlace?>> GetAsync(GetParkingPlaceRequest request);
    Task<PagedResponse<IList<ParkingPlace>>> GetListAsync(GetListParkingPlaceRequest request);
}
