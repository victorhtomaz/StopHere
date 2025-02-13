using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.ClientRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;
using StopHere.Core.ValueObjects;

namespace StopHere.Api.Handlers.ClientHandler;

public partial class ClientHandler
{
    public async Task<Response<Client?>> ChangeAsync(ChangeClientRequest request)
    {
        try
        {
            var client = await context.Clients.FirstOrDefaultAsync(c => c.Id == request.ClientId);
            if (client is null)
                return new Response<Client?>(null, EStatusCode.NotFound, "Cliente não encontrado");

            var phone = new Phone(request.PhoneNumber);
            if (!phone.Validate())
                return new Response<Client?>(null, EStatusCode.BadRequest, "Telefone inválido");

            var vehicle = await context.Vehicles
                    .FirstOrDefaultAsync(v => v.LicensePlate.Value.Equals(request.LicensePlateValue));
            if (vehicle is null)
                return new Response<Client?>(null, EStatusCode.NotFound, "Veículo não encontrado");

            client.ChangeInformation(request.Name, phone, vehicle);

            context.Clients.Update(client);
            await context.SaveChangesAsync();

            return new Response<Client?>(client, EStatusCode.Ok, "Cliente atualizado com sucesso");
        }
        catch (DbUpdateException)
        {
            return new Response<Client?>(null, EStatusCode.BadRequest, "Falha ao atualizar cliente");
        }
        catch
        {
            return new Response<Client?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
