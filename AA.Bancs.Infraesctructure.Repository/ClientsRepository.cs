using AA.Bancs.Domain.Entity;
using AA.Bancs.Infraestructure.Data;
using AA.Bancs.Infraestructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace AA.Bancs.Infraesctructure.Repository
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
            var clientToUpdate = await GetClientByIdAsync(clients.ClientId);

            clientToUpdate.Adress = clients.Adress;

            var response = await SaveAsync();
            return response;
        }

        public async Task<bool> SaveAsync()
        {
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }
    }
}