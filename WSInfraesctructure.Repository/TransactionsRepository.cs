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

        public Task<IEnumerable<Transactions>> GetAllTransactionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Transactions> GetTransactionsByIdAsync(Guid transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transactions>> GetTransactionsReport(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Transactions transactions)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Transactions transactions)
        {
            throw new NotImplementedException();
        }
    }
}