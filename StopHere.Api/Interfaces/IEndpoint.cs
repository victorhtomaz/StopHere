﻿namespace StopHere.Api.Interfaces;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}
