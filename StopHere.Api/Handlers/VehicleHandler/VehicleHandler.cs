using StopHere.Api.Data;
using StopHere.Core.Dtos.Requests.VehicleRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Handlers;

namespace StopHere.Api.Handlers.VehicleHandler;

public partial class VehicleHandler(AppDbContext context) : IVehicleHandler
{
}
