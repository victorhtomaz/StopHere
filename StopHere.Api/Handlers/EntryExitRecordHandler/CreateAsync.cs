using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.EntryExitRecordRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;

namespace StopHere.Api.Handlers.EntryExitRecordHandler;

public partial class EntryExitRecordHandler
{
    public async Task<Response<EntryExitRecord?>> CreateAsync(CreateEntryExitRecordRequest request)
    {
        try
        {
            var parkingPlace = await context.ParkingPlaces.FirstOrDefaultAsync(p => p.Number == request.Number);
            if (parkingPlace is null)
                return new Response<EntryExitRecord?>(null, EStatusCode.NotFound, "Vaga não encontrada");

            if (parkingPlace.IsOccupied)
                return new Response<EntryExitRecord?>(null, EStatusCode.BadRequest, "Vaga já está ocupada");

            var vehicle = await context.Vehicles
                .FirstOrDefaultAsync(v => v.LicensePlate.Value.Equals(request.LicensePlateValue));
            if (vehicle is null)
                return new Response<EntryExitRecord?>(null, EStatusCode.NotFound, "Veiculo não encontrado");

            parkingPlace.IsOccupied = true;

            var entryExitRecord = new EntryExitRecord(vehicle, parkingPlace);

            await context.EntryExitRecords.AddAsync(entryExitRecord);
            await context.SaveChangesAsync();

            return new Response<EntryExitRecord?>(entryExitRecord, EStatusCode.Created, "Registro criado com sucesso");

        }
        catch (DbUpdateException)
        {
            return new Response<EntryExitRecord?>(null, EStatusCode.BadRequest, "Falha ao criar registro");
        }
        catch
        {
            return new Response<EntryExitRecord?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
