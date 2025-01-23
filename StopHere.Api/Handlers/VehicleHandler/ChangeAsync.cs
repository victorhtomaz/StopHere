using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.VehicleRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;

namespace StopHere.Api.Handlers.VehicleHandler;

public partial class VehicleHandler
{
    public async Task<Response<Vehicle?>> ChangeAsync(ChangeVehicleRequest request)
    {
        try
        {
            var vehicle = await context.Vehicles
                    .FirstOrDefaultAsync(v => v.LicensePlate.Value == request.LicensePlateValue);

            if (vehicle is null)
                return new Response<Vehicle?>(null, Core.Enums.EStatusCode.BadRequest, "Veiculo não encontrado");

            vehicle.ChangeInformation(request.Color, request.Model);

            context.Vehicles.Update(vehicle);
            await context.SaveChangesAsync();

            return new Response<Vehicle?>(vehicle, EStatusCode.Ok, "Veiculo atualizado com sucesso");
        }
        catch (DbUpdateException)
        {
            return new Response<Vehicle?>(null, EStatusCode.BadRequest, "Falha ao atualizar veiculo");
        }
        catch
        {
            return new Response<Vehicle?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}