using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.ParkingPlaceRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;

namespace StopHere.Api.Handlers.ParkingPlaceHandler;

public partial class ParkingPlaceHandler
{
    public async Task<Response<ParkingPlace?>> CreateAsync(CreateParkingPlaceRequest request)
    {
        try
        {
            var parkingPlace = new ParkingPlace(request.Number);

            await context.ParkingPlaces.AddAsync(parkingPlace);
            await context.SaveChangesAsync();

            return new Response<ParkingPlace?>(parkingPlace, EStatusCode.Created, "Vaga criada com sucesso");
        }
        catch (DbUpdateException)
        {
            return new Response<ParkingPlace?>(null, EStatusCode.BadRequest, "Falha ao criar vaga");
        }
        catch
        {
            return new Response<ParkingPlace?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
