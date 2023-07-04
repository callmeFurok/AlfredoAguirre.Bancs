using Microsoft.EntityFrameworkCore;
using WSDomain.Entity;
using WSInfraestructure.Data;
using WSInfraestructure.Interface;

namespace WSInfraesctructure.Repository
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AccountsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> DeleteAsync(Guid accountId)
        {
            var accountToDelete = await GetAccountByIdAsync(accountId);

            _applicationDbContext.Accounts.Remove(accountToDelete);

            return await SaveAsync();
        }

        public async Task<Accounts> GetAccountByIdAsync(Guid accountId)
        {
            var account = await _applicationDbContext.Accounts.FindAsync(accountId);
            return account;
        }

        public async Task<IEnumerable<Accounts>> GetAllAccountsByClientIdAsync(Guid clientId)
        {
            var accounts = await _applicationDbContext.Accounts.Where(x => x.ClientId == clientId).ToListAsync();
            return accounts;
        }

        public async Task<bool> InsertAsync(Accounts account)
        {
            await _applicationDbContext.Accounts.AddAsync(account);
            var response = await SaveAsync();

            return response;
        }

        public async Task<bool> SaveAsync()
        {
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Accounts account)
        {
            var accountToUpdate = await GetAccountByIdAsync(account.AccountId);
            accountToUpdate = account;

            _applicationDbContext.Update(accountToUpdate);


            return await SaveAsync();

        }
    }
}