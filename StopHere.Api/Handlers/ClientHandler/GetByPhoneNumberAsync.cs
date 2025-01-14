using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.ClientRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;

namespace StopHere.Api.Handlers.ClientHandler;

public partial class ClientHandler
{
    public async Task<Response<Client?>> GetByPhoneNumberAsync(GetClientByPhoneNumberRequest request)
    {
        try
        {
            var client = await context.Clients.AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Phone.Number.Equals(request.PhoneNumber));
            if (client is null)
                return new Response<Client?>(null, EStatusCode.NotFound, "Cliente não encontrado");

            return new Response<Client?>(client, EStatusCode.Ok);
        }
        catch
        {
            return new Response<Client?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
