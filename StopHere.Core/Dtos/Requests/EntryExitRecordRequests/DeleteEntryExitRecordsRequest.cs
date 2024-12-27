namespace StopHere.Core.Dtos.Requests.EntryExitRecordRequests;

public class DeleteEntryExitRecordsRequest : Request
{
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}
