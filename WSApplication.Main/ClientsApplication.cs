using AutoMapper;
using Microsoft.Extensions.Configuration;
using WSApplication.Interface;
using WSApplications.DTO;
using WSDomain.Entity;
using WSDomain.Interface;
using WSTransversal.Commom;

namespace WSApplication.Main
{
    public class ClientsApplication : IClientsApplication
    {
        private readonly IClientsDomain _clientsDomain;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ClientsApplication(IClientsDomain clientsDomain, IMapper mapper, IConfiguration configuration)
        {
            _clientsDomain = clientsDomain;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<Response<bool>> DeleteAsync(Guid clientId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _clientsDomain.DeleteAsync(clientId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = _configuration.GetSection("Messages")["DeleteSuccess"];
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