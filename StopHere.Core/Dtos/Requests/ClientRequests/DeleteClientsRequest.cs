namespace StopHere.Core.Dtos.Requests.ClientRequests;

public class DeleteClientsRequest : Request
{
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}
