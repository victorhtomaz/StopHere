using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.ParkingPlaceRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;

namespace StopHere.Api.Handlers.ParkingPlaceHandler;

public partial class ParkingPlaceHandler
{
    public async Task<PagedResponse<IList<ParkingPlace>>> GetListAsync(GetListParkingPlaceRequest request)
    {
        try
        {
            var query = context.ParkingPlaces.AsNoTracking().OrderBy(x => x.Number);

            var totalCount = await query.CountAsync();

            var parkingPlaces = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize).ToListAsync();

            return new PagedResponse<IList<ParkingPlace>>(parkingPlaces, totalCount, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<IList<ParkingPlace>>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
