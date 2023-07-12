using WSDomain.Entity;
using WSDomain.Interface;
using WSInfraestructure.Interface;

namespace WSDomain.Core
{
    public enum TransactionType
    {
        Credit = 1,
        Debit = 2
    }
    public class TransactionsDomain : ITransactionsDomain
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IAccountsDomain _accountsDomain;

        public TransactionsDomain(ITransactionsRepository transactionsRepository, IAccountsDomain accountsDomain)
        {
            _transactionsRepository = transactionsRepository;
            _accountsDomain = accountsDomain;
        }
        public async Task<bool> DeleteAsync(Guid transactionId)
        {
            return await _transactionsRepository.DeleteAsync(transactionId);
        }

        public async Task<IEnumerable<Transactions>> GetAllTransactionsAsync(Guid accountId)
        {
            return await _transactionsRepository.GetAllTransactionsAsync(accountId);
        }

        public async Task<Transactions> GetTransactionsByIdAsync(Guid transactionId)
        {
            return await _transactionsRepository.GetTransactionsByIdAsync(transactionId);
        }

        public async Task<IEnumerable<Transactions>> GetTransactionsReportAsync(Guid accountId, DateTime startDate, DateTime endDate)
        {
            var transactions = await _transactionsRepository.GetTransactionsReportAsync(accountId, startDate, endDate);
            return transactions;
        }

        public async Task<bool> InsertAsync(Transactions transactions)
        {
            var account = await _accountsDomain.GetAccountByIdAsync(transactions.AccountId);

            if (transactions.TransactionType == (int)TransactionType.Debit)
            {
                if (account.InitialBalance < transactions.Amount) return false;

                transactions.Balance = account.InitialBalance - transactions.Amount;
                account.InitialBalance = transactions.Balance;
                await _accountsDomain.UpdateAsync(account);

                return await _transactionsRepository.InsertAsync(transactions);

            }

            transactions.Balance = account.InitialBalance + transactions.Amount;
            account.InitialBalance = transactions.Balance;
            await _accountsDomain.UpdateAsync(account);

            return await _transactionsRepository.InsertAsync(transactions);

        }

        public async Task<bool> UpdateAsync(Transactions transactions)
        {
            return await _transactionsRepository.UpdateAsync(transactions);
        }
    }
}
