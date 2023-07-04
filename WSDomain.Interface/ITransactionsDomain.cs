using WSDomain.Entity;

namespace WSDomain.Interface
{
    public interface ITransactionsDomain
    {
        Task<bool> InsertAsync(Transactions transactions);

        Task<bool> UpdateAsync(Transactions transactions);

        Task<bool> DeleteAsync(Guid transactionId);

        Task<Transactions> GetTransactionsByIdAsync(Guid transactionId);

        Task<IEnumerable<Transactions>> GetAllTransactionsAsync(Guid accountId);
        Task<IEnumerable<Transactions>> GetTransactionsReport(DateTime startDate, DateTime endDate);
    }
}
