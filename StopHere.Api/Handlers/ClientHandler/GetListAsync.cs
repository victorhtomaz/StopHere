using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.ClientRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;

namespace StopHere.Api.Handlers.ClientHandler;

public partial class ClientHandler
{
    public async Task<PagedResponse<IList<Client>>> GetListAsync(GetListClientRequest request)
    {
        try
        {
            var query = context.Clients.AsNoTracking().OrderBy(x => x.Name);

            var totalCount = await query.CountAsync();

            var clients = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize).ToListAsync();

            return new PagedResponse<IList<Client>>(clients, totalCount, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<IList<Client>>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
