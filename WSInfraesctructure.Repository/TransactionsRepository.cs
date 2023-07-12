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

        public async Task<bool> DeleteAsync(Guid transactionId)
        {
            await _applicationDbContext.Transactions.FirstOrDefaultAsync(x => x.TransactionId == transactionId);
            var response = await SaveAsync();
            return response;

        }

        public async Task<IEnumerable<Transactions>> GetAllTransactionsAsync(Guid accountId)
        {
            var transacctions = await _applicationDbContext.Transactions.Where(x => x.AccountId == accountId).OrderBy(x => x.Date).ToListAsync();

            return transacctions;
        }

        public async Task<Transactions> GetTransactionsByIdAsync(Guid transactionId)
        {
            var transaction = await _applicationDbContext.Transactions.FirstOrDefaultAsync(x => x.TransactionId == transactionId);

            return transaction;
        }

        public async Task<IEnumerable<Transactions>> GetTransactionsReportAsync(Guid accountId, DateTime startDate, DateTime endDate)
        {
            var transacctionsReport = await _applicationDbContext.Transactions.Where(x => x.AccountId == accountId && x.Date >= startDate && x.Date <= endDate).OrderBy(x => x.Date).ToListAsync();
            return transacctionsReport;
        }

        public async Task<bool> InsertAsync(Transactions transactions)
        {
            await _applicationDbContext.Transactions.AddAsync(transactions);
            var response = await SaveAsync();

            return response;
        }

        public async Task<bool> UpdateAsync(Transactions transactions)
        {
            _applicationDbContext.Transactions.Update(transactions);
            var respose = await SaveAsync();
            return respose;
        }
        public async Task<bool> SaveAsync()
        {
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

    }
}