using AA.Bancs.Domain.Entity;

namespace AA.Bancs.Domain.Interface
{
    public interface IClientsDomain
    {
        Task<bool> InsertAsync(Clients client);

        Task<bool> UpdateAsync(Clients client);

        Task<bool> DeleteAsync(Guid clientId);

        Task<Clients> GetClientByIdAsync(Guid clientId);

        Task<IEnumerable<Clients>> GetAllClientsAsync();
    }
}