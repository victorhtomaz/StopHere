using StopHere.Core.Dtos.Requests.EntryExitRecordRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;

namespace StopHere.Core.Handlers;

public interface IEntryExitRecordHandler
{
    Task<Response<EntryExitRecord?>> Create(CreateEntryExitRecordRequest request);
    Task<Response<EntryExitRecord?>> ChangeExit(ChangeExitEntryExitRecordRequest request);
    Task<Response<EntryExitRecord?>> Get(GetEntryExitRecordRequest request);
    Task<PagedResponse<IList<EntryExitRecord?>>> GetListByPeriod(GetListEntryExitRecordRequest request);
    Task<Response<EntryExitRecord?>> DeleteList(DeleteEntryExitRecordsRequest request);
}
