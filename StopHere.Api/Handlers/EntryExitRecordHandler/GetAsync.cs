using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.EntryExitRecordRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;

namespace StopHere.Api.Handlers.EntryExitRecordHandler;

public partial class EntryExitRecordHandler
{
    public async Task<Response<EntryExitRecord?>> GetAsync(GetEntryExitRecordRequest request)
    {
        try
        {
            var entryExitRecord = await context.EntryExitRecords.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == request.Id);
            if (entryExitRecord is null)
                return new Response<EntryExitRecord?>(null, EStatusCode.NotFound, "Registro não encontrado");

            return new Response<EntryExitRecord?>(entryExitRecord, EStatusCode.Ok);
        }
        catch
        {
            return new Response<EntryExitRecord?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
