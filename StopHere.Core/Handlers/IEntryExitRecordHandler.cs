using StopHere.Core.Dtos.Requests.EntryExitRecordRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;

namespace StopHere.Core.Handlers;

public interface IEntryExitRecordHandler
{
    Task<Response<EntryExitRecord?>> CreateAsync(CreateEntryExitRecordRequest request);
    Task<Response<EntryExitRecord?>> ChangeExitAsync(ChangeExitEntryExitRecordRequest request);
    Task<Response<EntryExitRecord?>> GetAsync(GetEntryExitRecordRequest request);
    Task<PagedResponse<IList<EntryExitRecord>>> GetListByPeriodAsync(GetListEntryExitRecordRequest request);
    Task<Response<EntryExitRecord?>> DeleteListAsync(DeleteEntryExitRecordsRequest request);
}
