using WSDomain.Entity;

namespace WSInfraestructure.Interface
{
    public interface ITransactionsRepository
    {
        Task<bool> InsertAsync(Transactions transactions);

        Task<bool> UpdateAsync(Transactions transactions);

        Task<bool> DeleteAsync(Guid transactionId);

        Task<Transactions> GetTransactionsByIdAsync(Guid transactionId);

        Task<IEnumerable<Transactions>> GetAllTransactionsAsync(Guid accountId);
        Task<IEnumerable<Transactions>> GetTransactionsReportAsync(Guid accountId, DateTime startDate, DateTime endDate);
        Task<bool> SaveAsync();

    }
}