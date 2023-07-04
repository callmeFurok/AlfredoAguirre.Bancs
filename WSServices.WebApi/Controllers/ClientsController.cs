using Microsoft.AspNetCore.Mvc;
using WSApplication.Interface;
using WSApplications.DTO;

namespace WSServices.WebApi.Controllers
{
    [Route("api/clientes/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsApplication _clientsApplication;

        public ClientsController(IClientsApplication clientsApplication)
        {
            _clientsApplication = clientsApplication;
        }

        // Obtener todos los clientes
        [HttpGet]
        [ActionName("obtenerClientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllClientsAsync()
        {
            var response = await _clientsApplication.GetAllClientsAsync();
            // validacion para verificar que las capas inferiores se realizaron correctamente
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        // Obtener cliente por id
        [HttpGet("{clientId}")]
        [ActionName("obtenerClientePorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetClientByIdAsync(Guid clientId)
        {
            var response = await _clientsApplication.GetClientByIdAsync(clientId);
            // validacion para verificar que las capas inferiores se realizaron correctamente
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost]
        [ActionName("crearCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> InsertAsync([FromBody] ClientsDto clientsDto)
        {
            if (clientsDto == null)
            {
                return BadRequest();
            }

            var response = await _clientsApplication.InsertAsync(clientsDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut]
        [ActionName("actualizarCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateAsync([FromBody] ClientsDto clientsDto)
        {
            if (clientsDto == null)
            {
                return BadRequest();
            }

            var response = await _clientsApplication.UpdateAsync(clientsDto);
            // validacion para verificar que las capas inferiores se realizaron correctamente
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("{clientId}")]
        [ActionName("eliminarCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAsync(Guid clientId)
        {
            var response = await _clientsApplication.DeleteAsync(clientId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}