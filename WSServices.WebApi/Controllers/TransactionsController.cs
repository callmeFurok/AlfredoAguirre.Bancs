using Microsoft.AspNetCore.Mvc;
using WSApplication.DTO;
using WSApplication.Interface;

namespace WSServices.WebApi.Controllers
{
    [Route("api/movimientos/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsApplication _transactionsApplication;

        public TransactionsController(ITransactionsApplication transactionsApplication)
        {
            _transactionsApplication = transactionsApplication;
        }


        [HttpPost]
        [ActionName("crearMovimiento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> InsertAsync([FromBody] TransactionsDto transactionsDto)
        {
            if (transactionsDto == null)
            {
                return BadRequest();
            }

            var response = await _transactionsApplication.InsertAsync(transactionsDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }


        [HttpGet("{accountId}")]
        [ActionName("obtenerMovimientosPorCuentaId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetClientByIdAsync(Guid accountId)
        {
            var response = await _transactionsApplication.GetAllTransactionsAsync(accountId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }


    }
}
