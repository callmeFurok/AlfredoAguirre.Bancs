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

        [HttpGet("{accountId}")]
        [ActionName("obtenerMovimientosPorCuentaId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllTransactionsAsync(Guid accountId)
        {
            var response = await _transactionsApplication.GetAllTransactionsAsync(accountId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        [HttpGet("{transactionId}")]
        [ActionName("obtenerMovimientoPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetTransactionsByIdAsync(Guid transactionId)
        {
            var response = await _transactionsApplication.GetTransactionsByIdAsync(transactionId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{accountId}/{startDate}/{endDate}")]
        [ActionName("obtenerReporteMovimientos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetTransactionsReportAsync(Guid accountId, DateTime startDate, DateTime endDate)
        {
            var response = await _transactionsApplication.GetTransactionsReportAsync(accountId, startDate, endDate);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
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

        [HttpPut]
        [ActionName("actualizarMovimiento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateAsync([FromBody] TransactionsDto transactionsDto)
        {
            if (transactionsDto == null)
            {
                return BadRequest();
            }

            var response = await _transactionsApplication.UpdateAsync(transactionsDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("{transactionId}")]
        [ActionName("eliminarMovimiento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAsync(Guid transactionId)
        {
            var response = await _transactionsApplication.DeleteAsync(transactionId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}