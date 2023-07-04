using AutoMapper;
using WSApplication.DTO;
using WSApplication.Interface;
using WSDomain.Entity;
using WSDomain.Interface;
using WSTransversal.Commom;

namespace WSApplication.Main
{
    public class TransactionsApplication : ITransactionsApplication
    {
        private readonly IAccountsApplication _accountsApplication;
        private readonly ITransactionsDomain _transactionsDomain;
        private readonly IMapper _mapper;

        public TransactionsApplication(IAccountsApplication accountsApplication, ITransactionsDomain transactionsDomain, IMapper mapper)
        {
            _transactionsDomain = transactionsDomain;
            _accountsApplication = accountsApplication;
            _mapper = mapper;
        }
        public Task<Response<bool>> DeleteAsync(Guid transactionId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IEnumerable<Transactions>>> GetAllTransactionsAsync(Guid accountId)
        {
            var response = new Response<IEnumerable<Transactions>>();
            try
            {
                var transactions = await _transactionsDomain.GetAllTransactionsAsync(accountId);

                response.Data = transactions;

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa de las transacciones por cuenta";
                }

            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }

        public Task<Response<Transactions>> GetTransactionsByIdAsync(Guid transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<Transactions>>> GetTransactionsReport(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> InsertAsync(TransactionsDto transactionsDto)
        {
            var response = new Response<bool>();
            try
            {
                var transacctionMap = _mapper.Map<Transactions>(transactionsDto);
                var accountInitialBalance = await _accountsApplication.GetAccountByIdAsync(transacctionMap.AccountId);

                transacctionMap.InitialBalance = accountInitialBalance.Data.InitialBalance;

                response.Data = await _transactionsDomain.InsertAsync(transacctionMap);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public Task<Response<bool>> UpdateAsync(TransactionsDto transactionsDto)
        {
            throw new NotImplementedException();
        }
    }
}
