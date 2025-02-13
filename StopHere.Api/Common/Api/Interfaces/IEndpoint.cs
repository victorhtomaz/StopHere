namespace StopHere.Api.Common.Api.Interfaces;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}
