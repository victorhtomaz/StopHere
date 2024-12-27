namespace StopHere.Core.Dtos.Requests.EntryExitRecordRequests;

public class GetListEntryExitRecordRequest : PagedRequest
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

