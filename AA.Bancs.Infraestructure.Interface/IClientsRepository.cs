using AA.Bancs.Domain.Entity;

namespace AA.Bancs.Infraestructure.Interface
{
    public interface IClientsRepository
    {
        Task<bool> InsertAsync(Clients clients);

        Task<bool> UpdateAsync(Clients clients);

        Task<bool> DeleteAsync(Guid clientId);

        Task<Clients> GetClientByIdAsync(Guid clientId);

        Task<IEnumerable<Clients>> GetAllClientsAsync();

        Task<bool> SaveAsync();
    }
}