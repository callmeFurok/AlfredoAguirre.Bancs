using WSApplication.DTO;
using WSDomain.Entity;
using WSTransversal.Commom;

namespace WSApplication.Interface
{
    public interface IAccountsApplication
    {
        Task<Response<bool>> InsertAsync(AccountsDto accountDto);

        Task<Response<bool>> UpdateAsync(AccountsDto accountDto);

        Task<Response<bool>> DeleteAsync(Guid accountId);

        Task<Response<AccountsDto>> GetAccountByIdAsync(Guid accountId);

        Task<Response<IEnumerable<Accounts>>> GetAllAccountsByClientIdAsync(Guid clientId);
    }
}
