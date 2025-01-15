using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.VehicleRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;

namespace StopHere.Api.Handlers.VehicleHandler;

public partial class VehicleHandler
{
    public async Task<Response<Vehicle?>> DeleteListAsync(DeleteVehiclesRequest request)
    {
        try
        {
            var vehicles = await context.Vehicles.
                Where(v => request.LicensePlateValues.Contains(v.LicensePlate.Value)).ToListAsync();

            if (!vehicles.Any() || vehicles is null)
                return new Response<Vehicle?>(null, EStatusCode.NotFound, "Nenhum veiculo encontrado");

            context.Vehicles.RemoveRange();
            await context.SaveChangesAsync();

            return new Response<Vehicle?>(null, EStatusCode.Ok, "Veiculos deletados com sucesso");
        }
        catch (DbUpdateException)
        {
            return new Response<Vehicle?>(null, EStatusCode.BadRequest, "Falha ao deletar veiculos");
        }
        catch
        {
            return new Response<Vehicle?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
