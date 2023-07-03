using AA.Bancs.Domain.Entity;

namespace AA.Bancs.Infraestructure.Interface
{
    public interface IAccountsRepository
    {
        Task<bool> InsertAsync(Accounts accounts);

        Task<bool> UpdateAsync(Accounts accounts);

        Task<bool> DeleteAsync(string accountId);

        Task<Accounts> GetAccountIdAsync(string accountId);

        Task<IEnumerable<Accounts>> GetAllAccountsAsync();
    }
}