using Microsoft.EntityFrameworkCore;
using WSDomain.Entity;
using WSInfraestructure.Data;
using WSInfraestructure.Interface;

namespace WSInfraesctructure.Repository
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ClientsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> DeleteAsync(Guid clientId)
        {
            var clientToDelete = await GetClientByIdAsync(clientId);
            _applicationDbContext.Clients.Remove(clientToDelete);
            var response = await SaveAsync();
            return response;
        }

        public async Task<IEnumerable<Clients>> GetAllClientsAsync()
        {
            var clients = await _applicationDbContext.Clients.ToListAsync();
            return clients;
        }

        public async Task<Clients> GetClientByIdAsync(Guid clientId)
        {
            // get client using clientId
            var client = await _applicationDbContext.Clients.FindAsync(clientId);
            return client;
        }

        public async Task<bool> InsertAsync(Clients clients)
        {
            await _applicationDbContext.Clients.AddAsync(clients);
            var response = await SaveAsync();
            return response;
        }

        public async Task<bool> UpdateAsync(Clients clients)
        {
            // actualizar cliente 
            var clientToUpdate = await GetClientByIdAsync(clients.ClientId);
            clientToUpdate = clients;

            _applicationDbContext.Update(clientToUpdate);

            var response = await SaveAsync();
            return response;
        }

        public async Task<bool> SaveAsync()
        {
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }
    }
}