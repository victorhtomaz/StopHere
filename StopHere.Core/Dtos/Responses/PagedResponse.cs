using System.Text.Json.Serialization;
using StopHere.Core.Enums;

namespace StopHere.Core.Dtos.Responses;

public class PagedResponse<TData> : Response<TData>
{
    public PagedResponse(TData? data, EStatusCode code, string? message = null) : base(data, code, message)
    {

    }
    
    [JsonConstructor]
    public PagedResponse(TData? data, int totalCount, int currentPage = Configuration.DefaultPageNumber, 
        int pageSize = Configuration.DefaultPageSize) : base(data)
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }

    public int CurrentPage { get; init; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
}
