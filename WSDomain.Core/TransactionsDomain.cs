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
        public Task<bool> DeleteAsync(Guid transactionId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transactions>> GetAllTransactionsAsync(Guid accountId)
        {
            return await _transactionsRepository.GetAllTransactionsAsync(accountId);
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
            // crea una transaccion dependiendo si es credito suma el initialbalance mas el amount en el campo balance

        }

        public Task<bool> UpdateAsync(Transactions transactions)
        {
            throw new NotImplementedException();
        }
    }
}
