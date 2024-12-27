using StopHere.Core.Dtos.Requests.VehicleRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;

namespace StopHere.Core.Handlers;

public interface IVehicleHandler
{
    Task<Response<Vehicle?>> Create(CreateVehicleRequest request);
    Task<Response<Vehicle?>> Change(ChangeVehicleRequest request);
    Task<Response<Vehicle?>> DeleteList(DeleteVehiclesRequest request);
    Task<Response<Vehicle?>> Get(GetVehicleRequest request);
}
