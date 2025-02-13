using Microsoft.EntityFrameworkCore;
using StopHere.Core.Dtos.Requests.VehicleRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;
using StopHere.Core.Enums;
using StopHere.Core.ValueObjects;

namespace StopHere.Api.Handlers.VehicleHandler;

public partial class VehicleHandler
{
    public async Task<Response<Vehicle?>> CreateAsync(CreateVehicleRequest request)
    {
        try
        {
            var licensePlate = new LicensePlate(request.LicensePlateValue);
            if (!licensePlate.Validate())
                return new Response<Vehicle?>(null, EStatusCode.BadRequest, "Placa inválida");

            var vehicle = new
                Vehicle(request.Color, request.Model, licensePlate);

            await context.Vehicles.AddAsync(vehicle);
            await context.SaveChangesAsync();

            return new Response<Vehicle?>(vehicle, EStatusCode.Created, "Veiculo criado com sucesso");
        }
        catch (DbUpdateException)
        {
            return new Response<Vehicle?>(null, EStatusCode.BadRequest, "Falha ao criar veiculo");
        }
        catch
        {
            return new Response<Vehicle?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}
