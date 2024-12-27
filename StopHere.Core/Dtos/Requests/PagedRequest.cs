namespace StopHere.Core.Dtos.Requests;

public abstract class PagedRequest : Request
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
