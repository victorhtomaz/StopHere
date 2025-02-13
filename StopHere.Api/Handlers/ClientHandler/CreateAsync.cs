using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.ClientRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;
using StopHere.Core.ValueObjects;

namespace StopHere.Api.Handlers.ClientHandler;

public partial class ClientHandler
{
    public async Task<Response<Client?>> CreateAsync(CreateClientRequest request)
    {
        try
        {
            var phone = new Phone(request.PhoneNumber);
            var clientService = new ClientService(request.ServiceType);

            if (!phone.Validate())
                return new Response<Client?>(null, EStatusCode.BadRequest, "Telefone inválido");

            var vehicle = await context.Vehicles
                    .FirstOrDefaultAsync(v => v.LicensePlate.Value.Equals(request.LicensePlateValue));
            if (vehicle is null)
                return new Response<Client?>(null, EStatusCode.NotFound, "Veículo não encontrado");

            var parkingPlace = await context.ParkingPlaces
                    .FirstOrDefaultAsync(p => p.Number == request.ParkingPlaceNumber);
            if (parkingPlace is null)
                return new Response<Client?>(null, EStatusCode.NotFound, "Vaga não encontrada");

            if (parkingPlace.ClientId is not null)
                return new Response<Client?>(null, EStatusCode.BadRequest, "A vaga já possui cliente");

            var client = new Client
            (
                request.Name,
                phone,
                clientService,
                vehicle,
                parkingPlace
            );

            await context.Clients.AddAsync(client);
            await context.SaveChangesAsync();

            return new Response<Client?>(client, EStatusCode.Created, "Cliente criado com sucesso");
        }
        catch (DbUpdateException)
        {
            return new Response<Client?>(null, EStatusCode.BadRequest, "Falha ao criar cliente");
        }
        catch
        {
            return new Response<Client?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
