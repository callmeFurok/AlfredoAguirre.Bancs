using Microsoft.AspNetCore.Mvc;
using WSApplication.DTO;
using WSApplication.Interface;

namespace WSServices.WebApi.Controllers
{
    [Route("api/cuentas/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsApplication _accountsApplication;
        public AccountsController(IAccountsApplication accountsApplication)
        {
            _accountsApplication = accountsApplication;
        }


        [HttpPost]
        [ActionName("crearCuenta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> InsertAsync([FromBody] AccountsDto accountsDto)
        {
            if (accountsDto == null)
            {
                return BadRequest();
            }

            var response = await _accountsApplication.InsertAsync(accountsDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet]
        [ActionName("obtenerCuentaPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAccountByIdAsync(Guid accountId)
        {
            if (accountId == Guid.Empty)
            {
                return BadRequest();
            }

            var response = await _accountsApplication.GetAccountByIdAsync(accountId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet]
        [ActionName("obtenerTodasLasCuentasPorIdCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllAccountsByClientIdAsync(Guid clientId)
        {
            if (clientId == Guid.Empty)
            {
                return BadRequest();
            }

            var response = await _accountsApplication.GetAllAccountsByClientIdAsync(clientId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        // Eliminar cuenta por id de cuenta4

        [HttpDelete("{accountId}")]
        [ActionName("eliminarCuenta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAsync(Guid accountId)
        {
            var response = await _accountsApplication.DeleteAsync(accountId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }


        [HttpPut]
        [ActionName("actualizarCuenta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateAsync([FromBody] AccountsDto accountsDto)
        {
            if (accountsDto == null)
            {
                return BadRequest();
            }

            var response = await _accountsApplication.UpdateAsync(accountsDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }


    }
}
