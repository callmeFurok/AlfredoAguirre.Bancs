using WSDomain.Entity;
using WSDomain.Interface;
using WSInfraestructure.Interface;

namespace WSDomain.Core
{
    public class AccountsDomain : IAccountsDomain
    {
        private readonly IAccountsRepository _accountsRepository;
        public AccountsDomain(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async Task<bool> DeleteAsync(Guid accountId)
        {
            return await _accountsRepository.DeleteAsync(accountId);
        }

        public async Task<Accounts> GetAccountByIdAsync(Guid accountId)
        {
            return await _accountsRepository.GetAccountByIdAsync(accountId);
        }

        public async Task<IEnumerable<Accounts>> GetAllAccountsByClientIdAsync(Guid clientId)
        {
            return await _accountsRepository.GetAllAccountsByClientIdAsync(clientId);
        }

        public async Task<bool> InsertAsync(Accounts account)
        {
            return await _accountsRepository.InsertAsync(account);
        }

        public async Task<bool> UpdateAsync(Accounts account)
        {
            return await _accountsRepository.UpdateAsync(account);
        }
    }
}
