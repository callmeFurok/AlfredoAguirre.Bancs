using WSApplication.DTO;
using WSDomain.Entity;
using WSTransversal.Commom;

namespace WSApplication.Interface
{
    public interface ITransactionsApplication
    {
        Task<Response<bool>> InsertAsync(TransactionsDto transactionsDto);

        Task<Response<bool>> UpdateAsync(TransactionsDto transactionsDto);

        Task<Response<bool>> DeleteAsync(Guid transactionId);

        Task<Response<Transactions>> GetTransactionsByIdAsync(Guid transactionId);

        Task<Response<IEnumerable<Transactions>>> GetAllTransactionsAsync(Guid accountId);
        Task<Response<IEnumerable<Transactions>>> GetTransactionsReport(DateTime startDate, DateTime endDate);
    }
}
