using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.EntryExitRecordRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;

namespace StopHere.Api.Handlers.EntryExitRecordHandler;

public partial class EntryExitRecordHandler
{
    public async Task<Response<EntryExitRecord?>> ChangeExitAsync(ChangeExitEntryExitRecordRequest request)
    {
        try
        {
            var entryExitRecord = await context.EntryExitRecords
                .Include(e => e.ParkingPlace)
                .FirstOrDefaultAsync(e => e.Id == request.Id);
            if (entryExitRecord is null)
                return new Response<EntryExitRecord?>(null, EStatusCode.NotFound, "Registro não encontrado");

            entryExitRecord.ChangeExitDate();
            entryExitRecord.ParkingPlace.IsOccupied = false;

            context.EntryExitRecords.Update(entryExitRecord);
            await context.SaveChangesAsync();

            return new Response<EntryExitRecord?>(entryExitRecord, EStatusCode.Ok, "Registro atualizado com sucesso");
        }
        catch (DbUpdateException)
        {
            return new Response<EntryExitRecord?>(null, EStatusCode.BadRequest, "Falha ao atualizar registro");
        }
        catch
        {
            return new Response<EntryExitRecord?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
