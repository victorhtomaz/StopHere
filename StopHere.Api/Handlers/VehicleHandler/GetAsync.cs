using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.VehicleRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;

namespace StopHere.Api.Handlers.VehicleHandler;

public partial class VehicleHandler
{
    public async Task<Response<Vehicle?>> GetAsync(GetVehicleRequest request)
    {
        try
        {
            var vehicle = await context.Vehicles.AsNoTracking()
                    .FirstOrDefaultAsync(v => v.LicensePlate.Value == request.LicensePlateValue);

            if (vehicle is null)
                return new Response<Vehicle?>(null, Core.Enums.EStatusCode.BadRequest, "Veiculo não encontrado");

            return new Response<Vehicle?>(vehicle, Core.Enums.EStatusCode.Ok);
        }
        catch
        {
            return new Response<Vehicle?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
