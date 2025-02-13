using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.ClientRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;

namespace StopHere.Api.Handlers.ClientHandler;

public partial class ClientHandler
{
    public async Task<Response<Client?>> DeleteListAsync(DeleteClientsRequest request)
    {
        try
        {
            var clients = await context.Clients.Where(c => request.Ids.Contains(c.Id)).ToListAsync();
            if (!clients.Any() || clients is null)
                return new Response<Client?>(null, EStatusCode.NotFound, "Nenhum cliente encontrado");

            context.RemoveRange(clients);
            await context.SaveChangesAsync();

            return new Response<Client?>(null, EStatusCode.Ok, "Clientes deletados com sucesso");
        }
        catch (DbUpdateException)
        {
            return new Response<Client?>(null, EStatusCode.BadRequest, "Falha ao deletar cliente");
        }
        catch
        {
            return new Response<Client?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
