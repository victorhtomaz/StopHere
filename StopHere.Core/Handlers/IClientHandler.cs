using StopHere.Core.Dtos.Requests.ClientRequests;
using StopHere.Core.Dtos.Responses;
using StopHere.Core.Entities;

namespace StopHere.Core.Handlers;

public interface IClientHandler
{
    Task<Response<Client?>> Create(CreateClientRequest request);
    Task<Response<Client?>> Change(ChangeClientRequest request);
    Task<Response<Client?>> DeleteList(DeleteClientsRequest request);
    Task<Response<Client?>> GetByPhoneNumber(GetClientByPhoneNumberRequest request);
    Task<PagedResponse<IList<Client?>>> GetList(GetListClientRequest request);
    Task<Response<Client?>> RenewService(RenewServiceClientRequest request);
}
