using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.EntryExitRecordRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;

namespace StopHere.Api.Handlers.EntryExitRecordHandler;

public partial class EntryExitRecordHandler
{
    public async Task<Response<EntryExitRecord?>> DeleteListAsync(DeleteEntryExitRecordsRequest request)
    {
        try
        {
            var entryExitRecords = await context.EntryExitRecords.AsNoTracking()
                .Where(e => request.Ids.Contains(e.Id)).ToListAsync();
            if (!entryExitRecords.Any() || entryExitRecords is null)
                return new Response<EntryExitRecord?>(null, EStatusCode.NotFound, "Nenhum registro encontrado");

            context.EntryExitRecords.RemoveRange(entryExitRecords);
            await context.SaveChangesAsync();

            return new Response<EntryExitRecord?>(null, EStatusCode.Ok, "Registros deletados com sucessos");
        }
        catch
        {
            return new Response<EntryExitRecord?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
