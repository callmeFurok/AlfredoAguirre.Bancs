using WSDomain.Entity;

namespace WSDomain.Interface
{
    public interface IAccountsDomain
    {
        Task<bool> InsertAsync(Accounts account);

        Task<bool> UpdateAsync(Accounts account);

        Task<bool> DeleteAsync(Guid accountId);

        Task<Accounts> GetAccountByIdAsync(Guid accountId);

        Task<IEnumerable<Accounts>> GetAllAccountsByClientIdAsync(Guid clientId);

    }
}
