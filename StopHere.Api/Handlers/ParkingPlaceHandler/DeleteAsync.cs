using Azure.Core;
using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.ParkingPlaceRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;

namespace StopHere.Api.Handlers.ParkingPlaceHandler;

public partial class ParkingPlaceHandler
{
    public async Task<Response<ParkingPlace?>> DeleteAsync(DeleteParkingPlaceRequest request)
    {
        try
        {
            var parkingPlace = await context.ParkingPlaces.FirstOrDefaultAsync(p => p.Number == request.Number);
            if (parkingPlace is null)
                return new Response<ParkingPlace?>(null, EStatusCode.BadRequest, "Vaga não encontrada");

            context.ParkingPlaces.Remove(parkingPlace);
            await context.SaveChangesAsync();

            return new Response<ParkingPlace?>(null, EStatusCode.Ok, "Vaga deletada com sucesso");
        }
        catch (DbUpdateException)
        {
            return new Response<ParkingPlace?>(null, EStatusCode.BadRequest, "Falha ao deletar vaga");
        }
        catch
        {
            return new Response<ParkingPlace?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
