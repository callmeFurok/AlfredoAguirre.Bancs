using Microsoft.EntityFrameworkCore;
using WSDomain.Entity;
using WSInfraestructure.Data;
using WSInfraestructure.Interface;

namespace WSInfraesctructure.Repository
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TransactionsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<bool> DeleteAsync(Guid transactionId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transactions>> GetAllTransactionsAsync(Guid accountId)
        {
            var transacctions = await _applicationDbContext.Transactions.Where(x => x.AccountId == accountId).OrderBy(x => x.Date).ToListAsync();

            return transacctions;
        }

        public Task<Transactions> GetTransactionsByIdAsync(Guid transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transactions>> GetTransactionsReport(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(Transactions transactions)
        {
            await _applicationDbContext.Transactions.AddAsync(transactions);
            var response = await SaveAsync();

            return response;
        }

        public async Task<bool> SaveAsync()
        {
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public Task<bool> UpdateAsync(Transactions transactions)
        {
            throw new NotImplementedException();
        }
    }
}