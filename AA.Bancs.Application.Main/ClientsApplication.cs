using AA.Bancs.Application.Interface;
using AA.Bancs.Applications.DTO;
using AA.Bancs.Domain.Entity;
using AA.Bancs.Domain.Interface;
using AA.Bancs.Transversal.Commom;
using AutoMapper;

namespace AA.Bancs.Application.Main
{
    public class ClientsApplication : IClientsApplication
    {
        private readonly IClientsDomain _clientsDomain;
        private readonly IMapper _mapper;

        public ClientsApplication(IClientsDomain clientsDomain, IMapper mapper)
        {
            _clientsDomain = clientsDomain;
            _mapper = mapper;
        }

        public async Task<Response<bool>> DeleteAsync(Guid clientId)
        {
            var response = new Response<bool>();
            // bloque de excepciones
            try
            {
                // al ser string no se requiere mapeo
                response.Data = await _clientsDomain.DeleteAsync(clientId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Cliente eliminado";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<IEnumerable<ClientsDto>>> GetAllClientsAsync()
        {
            var response = new Response<IEnumerable<ClientsDto>>();
            try
            {
                var clients = await _clientsDomain.GetAllClientsAsync();
                response.Data = _mapper.Map<IEnumerable<ClientsDto>>(clients);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa de todos los clientes";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;

        }

        public async Task<Response<ClientsDto>> GetClientByIdAsync(Guid clientId)
        {
            var response = new Response<ClientsDto>();
            try
            {
                var client = await _clientsDomain.GetClientByIdAsync(clientId);
                response.Data = _mapper.Map<ClientsDto>(client);
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

        public async Task<Response<bool>> InsertAsync(ClientsDto clientDto)
        {
            var response = new Response<bool>();
            // bloque de excepciones
            try
            {
                var client = _mapper.Map<Clients>(clientDto);
                response.Data = await _clientsDomain.InsertAsync(client);
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

        public async Task<Response<bool>> UpdateAsync(ClientsDto clientDto)
        {
            var response = new Response<bool>();
            // bloque de excepciones
            try
            {
                var client = _mapper.Map<Clients>(clientDto);
                response.Data = await _clientsDomain.UpdateAsync(client);
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