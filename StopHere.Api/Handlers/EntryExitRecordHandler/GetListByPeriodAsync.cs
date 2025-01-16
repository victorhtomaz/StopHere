using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.EntryExitRecordRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;
using StopHere.Core.Extensions;

namespace StopHere.Api.Handlers.EntryExitRecordHandler;

public partial class EntryExitRecordHandler
{
    public async Task<PagedResponse<IList<EntryExitRecord>>> GetListByPeriodAsync(GetListEntryExitRecordRequest request)
    {
        try
        {
            request.StartDate ??= DateTime.Now.GetFirstDay();
            request.EndDate ??= DateTime.Now.GetLastDay();

            var query = context.EntryExitRecords.AsNoTracking()
                    .Where(e => e.EntryDate >= request.StartDate && e.EntryDate <= request.EndDate)
                    .OrderBy(e => e.EntryDate);

            var count = await query.CountAsync();

            var entryExitRecords = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

            return new PagedResponse<IList<EntryExitRecord>>(entryExitRecords, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<IList<EntryExitRecord>>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
