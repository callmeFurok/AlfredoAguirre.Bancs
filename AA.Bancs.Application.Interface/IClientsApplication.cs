using AA.Bancs.Applications.DTO;
using AA.Bancs.Transversal.Commom;

namespace AA.Bancs.Application.Interface
{
    public interface IClientsApplication
    {
        Task<Response<bool>> InsertAsync(ClientsDto clientDto);

        Task<Response<bool>> UpdateAsync(ClientsDto clientDto);

        Task<Response<bool>> DeleteAsync(Guid clientId);

        Task<Response<ClientsDto>> GetClientByIdAsync(Guid clientId);

        Task<Response<IEnumerable<ClientsDto>>> GetAllClientsAsync();
    }
}