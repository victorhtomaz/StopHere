using StopHere.Core.Dtos.Requests.ClientRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;

namespace StopHere.Core.Handlers;

public interface IClientHandler
{
    Task<Response<Client?>> CreateAsync(CreateClientRequest request);
    Task<Response<Client?>> ChangeAsync(ChangeClientRequest request);
    Task<Response<Client?>> DeleteListAsync(DeleteClientsRequest request);
    Task<Response<Client?>> GetByPhoneNumberAsync(GetClientByPhoneNumberRequest request);
    Task<PagedResponse<IList<Client?>>> GetListAsync(GetListClientRequest request);
    Task<Response<Client?>> RenewServiceAsync(RenewServiceClientRequest request);
}
