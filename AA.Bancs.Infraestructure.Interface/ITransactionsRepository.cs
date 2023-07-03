using AA.Bancs.Domain.Entity;

namespace AA.Bancs.Infraestructure.Interface
{
    public interface ITransactionsRepository
    {
        Task<bool> InsertAsync(Transactions transactions);

        Task<bool> UpdateAsync(Transactions transactions);

        Task<bool> DeleteAsync(string transactionId);

        Task<Transactions> GetTransactionsByIdAsync(string transactionId);

        Task<IEnumerable<Transactions>> GetAllTransactionsAsync();
    }
}