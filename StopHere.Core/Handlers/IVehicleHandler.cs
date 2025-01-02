using StopHere.Core.Dtos.Requests.VehicleRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;

namespace StopHere.Core.Handlers;

public interface IVehicleHandler
{
    Task<Response<Vehicle?>> CreateAsync(CreateVehicleRequest request);
    Task<Response<Vehicle?>> ChangeAsync(ChangeVehicleRequest request);
    Task<Response<Vehicle?>> DeleteListAsync(DeleteVehiclesRequest request);
    Task<Response<Vehicle?>> GetAsync(GetVehicleRequest request);
}
