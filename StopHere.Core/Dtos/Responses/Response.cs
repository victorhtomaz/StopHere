using StopHere.Core.Enums;
using System.Text.Json.Serialization;

namespace StopHere.Core.Dtos.Responses;

public class Response<TData>
{
    public Response() : this(default, EStatusCode.Ok, null)
    {
        StatusCode = EStatusCode.Ok;
    }

    public Response(TData? data, EStatusCode code = EStatusCode.Ok, string? message = null)
    {
        Data = data;
        StatusCode = code;
        Message = message;
    }

    public TData? Data { get; init; }
    public EStatusCode StatusCode { get; init; }
    public string? Message { get; init; }
    [JsonIgnore]
    public bool IsSuccess => (int)StatusCode is >= 200 and <= 299;
}
