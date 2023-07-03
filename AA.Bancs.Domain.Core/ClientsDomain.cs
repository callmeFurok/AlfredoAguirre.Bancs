using AA.Bancs.Domain.Entity;
using AA.Bancs.Domain.Interface;
using AA.Bancs.Infraestructure.Interface;

namespace AA.Bancs.Domain.Core
{
    public class ClientsDomain : IClientsDomain
    {
        private readonly IClientsRepository _clientsRepository;

        public ClientsDomain(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<bool> DeleteAsync(Guid clientId)
        {
            return await _clientsRepository.DeleteAsync(clientId);
        }

        public async Task<IEnumerable<Clients>> GetAllClientsAsync()
        {
            return await _clientsRepository.GetAllClientsAsync();
        }

        public async Task<Clients> GetClientByIdAsync(Guid clientId)
        {
            return await _clientsRepository.GetClientByIdAsync(clientId);
        }

        public async Task<bool> InsertAsync(Clients client)
        {
            return await _clientsRepository.InsertAsync(client);
        }

        public async Task<bool> UpdateAsync(Clients client)
        {
            return await _clientsRepository.UpdateAsync(client);
        }
    }
}