using AutoMapper;
using WSApplication.DTO;
using WSApplication.Interface;
using WSDomain.Entity;
using WSDomain.Interface;
using WSTransversal.Commom;

namespace WSApplication.Main
{
    public class AccountsApplication : IAccountsApplication
    {
        private readonly IAccountsDomain _accountsDomain;
        private readonly IMapper _mapper;
        public AccountsApplication(IAccountsDomain accountsDomain, IMapper mapper)
        {
            _accountsDomain = accountsDomain;
            _mapper = mapper;
        }
        public async Task<Response<bool>> DeleteAsync(Guid accountId)
        {
            var response = new Response<bool>();
            try
            {
                var account = await _accountsDomain.DeleteAsync(accountId);
                response.Data = account;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Cuenta eliminada exitosamente";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<AccountsDto>> GetAccountByIdAsync(Guid accountId)
        {
            var response = new Response<AccountsDto>();
            try
            {
                var account = await _accountsDomain.GetAccountByIdAsync(accountId);
                response.Data = _mapper.Map<AccountsDto>(account);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa de cliente por Id";
                }

            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<Accounts>>> GetAllAccountsByClientIdAsync(Guid clientId)
        {
            var response = new Response<IEnumerable<Accounts>>();
            try
            {
                var accounts = await _accountsDomain.GetAllAccountsByClientIdAsync(clientId);

                response.Data = accounts;
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa de todas las cuentas";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> InsertAsync(AccountsDto accountDto)
        {
            var response = new Response<bool>();

            try
            {
                var account = _mapper.Map<Accounts>(accountDto);

                response.Data = await _accountsDomain.InsertAsync(account);

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

        public async Task<Response<bool>> UpdateAsync(AccountsDto account)
        {
            var response = new Response<bool>();
            try
            {
                var accountUpdate = _mapper.Map<Accounts>(account);
                response.Data = await _accountsDomain.UpdateAsync(accountUpdate);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
