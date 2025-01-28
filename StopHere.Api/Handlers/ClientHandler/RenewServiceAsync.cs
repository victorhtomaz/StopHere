using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.ClientRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;
using StopHere.Core.ValueObjects;

namespace StopHere.Api.Handlers.ClientHandler;

public partial class ClientHandler
{
    public async Task<Response<Client?>> RenewServiceAsync(RenewServiceClientRequest request)
    {
        try
        {
            var client = await context.Clients.FirstOrDefaultAsync(c => c.Id == request.ClientId);
            if (client is null)
                return new Response<Client?>(null, EStatusCode.NotFound, "Cliente não encontrado");

            var service = new ClientService(request.ServiceType);

            var parkingPlace = await context.ParkingPlaces
                    .FirstOrDefaultAsync(p => p.Number == request.ParkingPlaceNumber);
            if (parkingPlace is null)
                return new Response<Client?>(null, EStatusCode.NotFound, "Vaga não encontrada");

            if (parkingPlace.ClientId is not null && parkingPlace.ClientId != client.Id)
                return new Response<Client?>(null, EStatusCode.BadRequest, "A vaga já possui cliente");

            client.Renew(service, parkingPlace);

            context.Clients.Update(client);
            await context.SaveChangesAsync();

            return new Response<Client?>(client, EStatusCode.Ok, "Renovação concluida com sucesso");
        }
        catch (DbUpdateException)
        {
            return new Response<Client?>(null, EStatusCode.BadRequest, "Falha ao renovar o serviço");
        }
        catch
        {
            return new Response<Client?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
